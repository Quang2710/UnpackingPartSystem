import { DatePipe } from '@angular/common';
import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
    selector: 'app-unpackingLot',
    templateUrl: './unpackingLot.component.html',
    styleUrls: ['./unpackingLot.component.less']
})
export class UnpackingLotComponent extends AppComponentBase implements OnInit {

    rowdata: any[] = [];
    paginationParams: PaginationParamsModel = {
        pageNum: 1,
        pageSize: 20,
        totalCount: 0,
        skipCount: 0,
        sorting: '',
        totalPage: 1,
    };
    unpackingNo;
    moduleNo;
    renban;
    suppilerNo;
    shiftNo;
    workingDate;
    planUnpackingDate;
    actUnpackingDate;
    actUnpackingDateFinish;
    unpackingType;
    unpackingStatus;

    constructor(
        injector: Injector,
        private _service: UnpackingServiceProxy,
        private gridTableService: GridTableService,
        private _fileDownloadService: FileDownloadService,
        private datePipe: DatePipe

    ) {
        super(injector)
    }

    ngOnInit() {
        this.getDatas();
    }
    getDatas() {
        this._service.getAll(
            this.unpackingNo,
            this.moduleNo,
            this.renban,
            this.suppilerNo,
            this.shiftNo,
            this.unpackingType,
            this.unpackingStatus,
            '',
            this.paginationParams.skipCount,
            this.paginationParams.pageSize
        )
            .subscribe((result) => {
                this.rowdata = result.items;
                console.log(this.rowdata);
            });

    }

    exportToExcel(): void {
        // this.loaderVisible();
        this._service
            .getUnpackingToExcel(
                this.unpackingNo,
                this.moduleNo,
                this.renban,
                this.suppilerNo,
                this.shiftNo,
                this.workingDate,
                this.planUnpackingDate,
                this.actUnpackingDate,
                this.actUnpackingDateFinish,
                this.unpackingType,
                this.unpackingStatus,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
                //this.loaderHidden();
            });
    }
}
