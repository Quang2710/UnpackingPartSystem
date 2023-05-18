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
  paginationParams: PaginationParamsModel = {
    pageNum: 1,
    pageSize: 20,
    totalCount: 0,
    skipCount: 0,
    sorting: '',
    totalPage: 1,
  };

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
      this.partName,
      '',
      this.paginationParams.skipCount,
      this.paginationParams.pageSize
    )
      .subscribe((result) => {
        this.rowdata = result.items;
        this.totalPart = this.rowdata.length;
        this.totalLot = this.totalPart / 10;

      });

  }

}
