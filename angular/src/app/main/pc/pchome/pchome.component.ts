import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PcHomeServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
    selector: 'app-pchome',
    templateUrl: './pchome.component.html',
    styleUrls: ['./pchome.component.less']
})
export class PcHomeComponent extends AppComponentBase implements OnInit {

    rowdata;
    partNo;
    partName;
    totalPart;
    totalLot;
    constructor(
        injector: Injector,
        private _service: PcHomeServiceProxy,
        private _fileDownloadService: FileDownloadService,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getDatas();
    }

    getDatas(partNo?) {
        this._service.getAll(
            partNo,
            this.partName
        )
            .subscribe((result) => {
                this.rowdata = result;
                this.totalPart = this.rowdata.length;
                this.totalLot = this.totalPart / 10;

            });

    }
     searchOrClear(type?) {
        this.partNo = (type === "Clear") ? '' : this.partNo;
        this.getDatas(this.partNo);
    }
    exportToExcel(): void {
        this._service
            .getPcHomeToExcel(
                this.partNo,
                this.partName,               
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

}
