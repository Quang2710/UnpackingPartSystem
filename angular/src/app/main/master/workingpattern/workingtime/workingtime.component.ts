import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { MstWptWorkingTimeDto, MstWptWorkingTimeServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng';

@Component({
    selector: 'app-workingtime',
    templateUrl: './workingtime.component.html',
    styleUrls: ['./workingtime.component.less'],
})
export class WorkingtimeComponent extends AppComponentBase implements OnInit {
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
    data: MstWptWorkingTimeDto = new MstWptWorkingTimeDto();
    dataParams: GridParams | undefined;

    shiftNo: number = 0;
    shopId: number = 0;
    shopName: string = '';
    workingType: number = 0;
    startTime: any;
    endTime: any;
    description: string = '';
    patternHId: number = 0;
    seasonType: string = '';
    dayOfWeek: string = '';
    weekWorkingDays: number = 0;
    isActive: string = '';

    constructor(
        injector: Injector,
        private _service: MstWptWorkingTimeServiceProxy,
        private gridTableService: GridTableService,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.paginationParams = { pageNum: 1, pageSize: 20, totalCount: 0 };
        this.getDatas();

    }

    getDatas() {
        this._service.getAll(
            this.shiftNo,
            this.shopId,
            this.workingType,
            this.description,
            this.patternHId,
            this.seasonType,
            this.dayOfWeek,
            this.weekWorkingDays,
            this.isActive,
            '',
            this.paginationParams.skipCount,
            this.paginationParams.pageSize
        )
            .subscribe((result) => {
                this.rowdata = result.items;
                console.log(this.rowdata);
            });

    }



}
