import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DevaningContModuleDto, DevaningContModuleServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { Paginator } from 'primeng';

@Component({
    selector: 'app-devaningCont',
    templateUrl: './devaningCont.component.html',
    styleUrls: ['./devaningCont.component.less']
})
export class DevaningContComponent extends AppComponentBase implements OnInit {
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    paginationParams: PaginationParamsModel = {
        pageNum: 1,
        pageSize: 20,
        totalCount: 0,
        skipCount: 0,
        sorting: '',
        totalPage: 1,
    };
    indexShort: number = 0;
    filterText: string = '';
    isLoading;
    rowdata: any[] = [];
    data: DevaningContModuleDto = new DevaningContModuleDto();
    dataParams: GridParams | undefined;

    devaningNo: string = '';
    containerNo: string = '';
    renban: string = '';
    suppilerNo: string = '';
    shiftNo: string = '';
    workingDate;
    planDevaningDate;
    actDevaningDate;
    actDevaningDateFinish;
    devaningType: string = '';
    devaningStatus: string = '';

    constructor(
        injector: Injector,
        private _service: DevaningContModuleServiceProxy,
        private gridTableService: GridTableService,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector)
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this.getDatas();

    }

    getDatas() {
        this._service.getAll(
            this.devaningNo,
            this.containerNo,
            this.renban,
            this.suppilerNo,
            this.shiftNo,
            this.devaningType,
            this.devaningStatus,
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
            .getDevaningContModuleToExcel(
                this.devaningNo,
                this.containerNo,
                this.renban,
                this.suppilerNo,
                this.shiftNo,
                this.workingDate,
                this.planDevaningDate,
                this.actDevaningDate,
                this.actDevaningDateFinish,
                this.devaningType,
                this.devaningStatus,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
                //this.loaderHidden();
            });
    }
}
