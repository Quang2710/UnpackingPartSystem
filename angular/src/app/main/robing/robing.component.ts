import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { RobingServiceProxy, UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { error } from 'console';
import * as moment from 'moment';


@Component({
    selector: 'robing',
    templateUrl: './robing.component.html',
    styleUrls: ['./robing.component.less'],
})
export class RobingComponent extends AppComponentBase implements OnInit {

    dateNow;

    robingToday;
    partFail;
    partLoan;
    totalRobing;

    rowdata;
    selectedDiv: any;
    partNo: string;
    renban: string;
    supplier: string;
    moduleNo: string;
    robingTime: any;
    description: string;

    increaseToday;
    increaseFail;
    increaseLoan;
    increaseTotal;

    arrayTest = ['1','2','3','4','5']
    listPartInModule;

    constructor(
        injector: Injector,
        private _service: RobingServiceProxy,
        private _unpackingProxy: UnpackingServiceProxy,
        private _fileDownloadService: FileDownloadService,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getAllRobing();
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.getTimeNow();
        }, 1000);
    }

    ngOnDestroy(): void {
        // clearTimeout(this.clearTimeLoadData);
    }


    getTimeNow() {
        const d = new Date();
        const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        this.dateNow = (((d.getHours() + "").length == 1) ?     ("0" + d.getHours()) : d.getHours()) + ":" + (((d.getMinutes() + "").length == 1) ? ("0" + d.getMinutes()) : d.getMinutes()) + " : " + (((d.getSeconds() + "").length == 1) ? ("0" + d.getSeconds()) : d.getSeconds()) + " ( " + (((month[d.getMonth()] + "").length == 1) ? ("0" + month[d.getMonth()]) : month[d.getMonth()]) + " - " + (((d.getDay() + "").length == 1) ? ("0" + d.getDay()) : d.getDay()) + " ) "
    }

    getAllRobing(partNo?) {
        this._service.getAllRobing(partNo)
            .subscribe((res) => {
                this.rowdata = res

                if (typeof this.totalRobing === 'undefined') {
                    this.totalRobing = this.rowdata.length;
                    this.partFail = this.rowdata.filter((e) => e.type == "FAILD").length
                    this.partLoan = this.rowdata.filter((e) => e.type == "LOAN").length

                    const currentDate = moment();

                    this.robingToday = this.rowdata.filter((e) => {
                        if (e.creationTime) {
                            const creationDate = moment(e.creationTime);
                            return creationDate.isSame(currentDate, 'day');
                        }
                        return false;
                    }).length;

                    this.increaseFail
                }

            }, (error) => {
                this.notify.error('ERROR', error)
            })
    }

    searchOrClear(type?) {
        this.partNo = (type === "Clear") ? '' : this.partNo;
        this.getAllRobing(this.partNo);
    }

    onchangeSelection(item, index) {
        if (this.selectedDiv === item) {
            this.selectedDiv = null;
        } else {
            this.selectedDiv = item;
        }
        // ?? error
        //this.robingDetail = this.rowdata[index]

        this.renban = this.rowdata[index].renban
        this.supplier = this.rowdata[index].supplier
        this.robingTime = this.rowdata[index].creationTime
        this.moduleNo = this.rowdata[index].moduleNo
        this.description = this.rowdata[index].description

        this.getPartInModule()


        // const iconRecommed = document.querySelector<HTMLElement>('.recommeded-icon .icon');
        // iconRecommed.classList.add('icon-slide');
        // setTimeout(()=>{
        //     iconRecommed.classList.remove('icon-slide')
        // },1000)

    }

    getPartInModule(){
        this._unpackingProxy.getPartInModule(this.moduleNo).subscribe((res)=>{
            this.listPartInModule =  res
        })
    }

    requestGiveBack(){
        this.message.confirm(this.l(''), 'REQUEST GIVE BACK TO '+this.supplier, (isConfirmed) => {
            if (isConfirmed) {
                return;
            }
          });
    }

    exportToExcel(): void {
        this._service
            .getRobingToExcel(
                this.partNo,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }


}




