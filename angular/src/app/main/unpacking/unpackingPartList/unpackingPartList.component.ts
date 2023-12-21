import { DatePipe } from '@angular/common';
import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UnpackingDto, UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
    selector: 'app-unpackingPartList',
    templateUrl: './unpackingPartList.component.html',
    styleUrls: ['./unpackingPartList.component.less']
})
export class UnpackingPartListComponent extends AppComponentBase implements OnInit {

    selectedRowdata: UnpackingDto = new UnpackingDto();
    rowdata: any[] = [];
    partNo;
    moduleNo;
    status;


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
        this._service.getAllPartList(
            this.partNo,
            this.moduleNo,
            this.status
        )
            .subscribe((result) => {
                this.rowdata = result;
                console.log(this.rowdata);
            });

    }

    clearTextSearch() {
        this.partNo = '';
        this.moduleNo = '';
        this.status = '';
        this.getDatas();

    }
    exportToExcel(): void {
        this._service
            .getAllPartListExcel(
                this.partNo,
                this.moduleNo,
                this.status
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
                this.notify.success('Export success')

            },(error)=>{
                this.notify.error('Export failed',error)
            });
    }
    onRowSelect(event) {
        const devaningNo = event.data.partNo;
        console.log('Selected Unpacking No: ', this.selectedRowdata);
    }
    getStatusBackgroundClass(status: string): string {
        if (status === 'ROBING') {
            return 'ROBING';
        } else if (status === 'FINISH') {
            return 'FINISH';
        }
    }

}
