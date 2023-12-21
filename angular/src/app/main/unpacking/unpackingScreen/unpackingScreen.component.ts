import { DatePipe } from '@angular/common';
import { Component, Injectable, Injector, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AddRobingComponent } from './add-robing.component';
import { error } from 'console';

@Component({
  selector: 'app-unpackingScreen',
  templateUrl: './unpackingScreen.component.html',
  styleUrls: ['./unpackingScreen.component.less']
})
@Injectable({
  providedIn: 'root'
})
export class UnpackingScreenComponent extends AppComponentBase implements OnInit {

  @ViewChild('addrobing') childModal :AddRobingComponent;

  rowdata;
  partStatus;
  partCurrent;
  modulePlan;
  moduleActual;
  moduleFinish;
  moduleNoCurrent;
  moduleNo;
  partNo;
  partName;
  moduleNoStatus;
  status;
  renban;
  supplier;
  partNoCurrent;
  moduleStatus;



  bsModalRef: BsModalRef;

  constructor(
    injector: Injector,
    private _service: UnpackingServiceProxy,
    private gridTableService: GridTableService,
    private _fileDownloadService: FileDownloadService,
    private modalService: BsModalService,
    private viewContainerRef: ViewContainerRef
  ) {
    super(injector)
  }

  ngOnInit() {
    this.getModulePlan();
  }
  ngAfterViewInit() {
    setInterval(() => {
      this.getDatas();
    }, 1000);
  }

  ngOnDestroy():void{
    }


  // GetModule Unpacking
  getModulePlan() {
    this._service.getModulePlan().subscribe((result) => {

      const upkModule = result.find(item => item.moduleStatus === 'UPK');
      this.moduleNoCurrent = upkModule ? upkModule.moduleNo : null;
      this.moduleActual = result.length;
      this.moduleFinish = result.filter(item => item.moduleStatus === 'FINISH').length;

      this.moduleNoStatus = upkModule ? 'UPK' : null;
      this.getDatas();
    });
  }

  // Get Part in Module Unpacking Current
  getDatas() {
    this._service.getPartInModule(this.moduleNoCurrent)
      .subscribe((result) => {
        this.rowdata = result;
        this.partStatus = result.filter(item => item.status !== 'READY').length;
        this.partCurrent = result.filter(item => item.status).length;

      });
  }

  finishUpkModule(id: string) {
    this.message.confirm(this.l(''), 'FINISH UNPACKING MODULE', (isConfirmed) => {
      if (isConfirmed) {
        this._service.finishUpkModule(id)
          .subscribe(() => {
            this.notify.success(this.l('FINISH Successfully '));
            this.getModulePlan();
          });
      }
    });
  }

  getStatusBackgroundClass(status: string): string {
    if (status === 'START') {
      return 'START';
    } else if (status === 'FINISH') {
      return 'FINISH';
    }
    else if (status === 'ROBING') {
      return 'ROBING';
    }
  }
  checkStatusModule(moduleStatus: string): string {
    if (moduleStatus === 'UPK') {
      return 'UPK';
    } else if (moduleStatus === 'DELAY') {
      return 'DELAY';
    }
  }
  addrobing(data) {
    this.bsModalRef = this.modalService.show(AddRobingComponent, {
      initialState: {
        partDetail: data
      }
    });
  }
  finishPart(record) {
    this.message.confirm(this.l('Are You Sure To Finish Part'), 'FINISH PART', (isConfirmed) => {
      if (isConfirmed) {
        this._service.finishPart(record.id).subscribe(_ => {
          this.notify.success(this.l('Finish success'));
          this.getModulePlan();
          this.checkFinishModule();
          console.log('finish part', record.id);
        }, (error) => {
          this.notify.error('Finish Error', error)
        })
      }

    });
  }
  checkFinishModule(){
    if(this.partStatus + 1 == this.partCurrent){
      this._service.finishUpkModule(this.moduleNoCurrent)
          .subscribe(() => {
            this.notify.success(this.l('FINISH Successfully '));
            this.getModulePlan();
          });
    }
  }
}
