import { Component, Injector, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PcStoreServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'app-pcstore',
    templateUrl: './pcstore.component.html',
    styleUrls: ['./pcstore.component.less']
})
export class PcStoreComponent extends AppComponentBase implements OnInit {

    rowdata;
    partNo;
    partName;
    totalPart;
    totalLot;
    constructor(
        injector: Injector,
        private _service: PcStoreServiceProxy,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getDatas();
    }

    getDatas() {
        this._service.getAll(
            this.partNo,
            this.partName
        )
            .subscribe((result) => {
                this.rowdata = result;
                this.totalPart = this.rowdata.length;
                this.totalLot = this.totalPart / 10;


            });

    }

}
