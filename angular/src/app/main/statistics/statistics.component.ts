import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { MstWptWorkingTimeDto, MstWptWorkingTimeServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng';

@Component({
    selector: 'statistics',
    templateUrl: './statistics.component.html',
    styleUrls: ['./statistics.component.less'],
})
export class StatisticsComponent extends AppComponentBase implements OnInit {
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    constructor(
        injector: Injector,
        private _service: MstWptWorkingTimeServiceProxy,
        private gridTableService: GridTableService,
    ) {
        super(injector)
    }

    ngOnInit() {


    }



    }




