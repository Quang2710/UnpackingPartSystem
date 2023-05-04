import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { MstWptWorkingTimeServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'app-workingtime',
    templateUrl: './workingtime.component.html',
    styleUrls: ['./workingtime.component.less']
})
export class WorkingtimeComponent implements OnInit {

    paginationParams: PaginationParamsModel = {
        pageNum: 1,
        pageSize: 20,
        totalCount: 0,
        skipCount: 0,
        sorting: '',
        totalPage: 1,
    };

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

    ) {

    }

    ngOnInit() {
    }

    getDatas(paginationParams?: PaginationParamsModel) {
        return this._service.getAll(
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
        );
    }

}
