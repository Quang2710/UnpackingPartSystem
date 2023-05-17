import { DatePipe } from '@angular/common';
import { Component, Injector, OnInit } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';

@Component({
  selector: 'app-unpackingScreen',
  templateUrl: './unpackingScreen.component.html',
  styleUrls: ['./unpackingScreen.component.less']
})
export class UnpackingScreenComponent extends AppComponentBase implements OnInit {

  rowdata;
  paginationParams: PaginationParamsModel = {
    pageNum: 1,
    pageSize: 20,
    totalCount: 0,
    skipCount: 0,
    sorting: '',
    totalPage: 1,
  };
  moduleNoCurrent;
  moduleNo = 'DVN1033TMT1';
  partNo;
  partName;
  status;
  renban;
  supplier;
  partNoCurrent;

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
    this._service.getPartInModule(this.moduleNo)
      .subscribe((result) => {
        this.rowdata = result;
        this.partNoCurrent = this.rowdata.filter(item => item.status === 'START')[0].partNo;
        console.log(this.rowdata);
      });

  }
  getStatusBackgroundClass(status: string): string {
    if (status === 'START') {
      return 'START';
    } else if (status === 'FINISH') {
      return 'FINISH';
    }
  }

}
