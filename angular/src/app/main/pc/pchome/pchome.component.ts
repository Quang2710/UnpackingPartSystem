import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PcHomeServiceProxy } from '@shared/service-proxies/service-proxies';

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
