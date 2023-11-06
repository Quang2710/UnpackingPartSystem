import { DatePipe } from '@angular/common';
import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UnpackingDto, UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
    selector: 'app-unpackingLot',
    templateUrl: './unpackingLot.component.html',
    styleUrls: ['./unpackingLot.component.less']
})
export class UnpackingLotComponent extends AppComponentBase implements OnInit {

    selectedRowdata: UnpackingDto = new UnpackingDto();
    rowdata: any[] = [];
    devaningNo;
    moduleNo;
    renban;
    supplier;
    shiftNo;
    workingDate;
    planUnpackingDate;
    actUnpackingDate;
    actUnpackingDateFinish;
    unpackingType;
    moduleStatus;

    constructor(
        injector: Injector,
        private _service: UnpackingServiceProxy,
        private _fileDownloadService: FileDownloadService,

    ) {
        super(injector)
    }

    ngOnInit() {
        this.getDatas();
    }
    getDatas() {
        this._service.getAll(
            this.moduleNo,
            this.devaningNo,
            this.renban,
            this.supplier,
            this.moduleStatus
        )
            .subscribe((result) => {
                this.rowdata = result;
                console.log(this.rowdata);
            });

    }

    clearTextSearch() {
        this.moduleNo = '';
        this.moduleStatus = '';
        this.getDatas();

    }
    exportToExcel(): void {
        this._service
            .getUnpackingToExcel(
                this.moduleNo,
                this.devaningNo,
                this.renban,
                this.supplier,
                this.actUnpackingDate,
                this.actUnpackingDateFinish,
                this.planUnpackingDate,
                this.moduleStatus,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
    onRowSelect(event) {
        const devaningNo = event.data.devaningNo;
        console.log('Selected Unpacking No: ', this.selectedRowdata);
    }
    getStatusBackgroundClass(status: string): string {
        if (status === 'UPK') {
            return 'UPK';
        } else if (status === 'FINISH') {
            return 'FINISH';
        }
    }

}
