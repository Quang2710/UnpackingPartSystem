import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataFormatService } from '@app/shared/common/services/data-format.service';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { RobingServiceProxy } from '@shared/service-proxies/service-proxies';
import { error } from 'console';
import * as moment from 'moment';


@Component({
    selector: 'robing',
    templateUrl: './robing.component.html',
    styleUrls: ['./robing.component.less'],
})
export class RobingComponent extends AppComponentBase implements OnInit {


    robingToday;
    partFail;
    partLoan;
    totalRobing;

    rowdata;
    selectedDiv: any;
    partNo: string;
    renban: string;
    supplier: string;
    robingTime: any;
    description: string;

    increaseToday;
    increaseFail;
    increaseLoan;
    increaseTotal;

    constructor(
        injector: Injector,
        private _service: RobingServiceProxy,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getAllRobing();
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
        this.description = this.rowdata[index].description

        console.log(this.robingTime);


        // const iconRecommed = document.querySelector<HTMLElement>('.recommeded-icon .icon');
        // iconRecommed.classList.add('icon-slide');
        // setTimeout(()=>{
        //     iconRecommed.classList.remove('icon-slide')
        // },1000)

    }

    requestGiveBack(){
        this.message.confirm(this.l(''), 'REQUEST GIVE BACK TO '+this.supplier, (isConfirmed) => {
            if (isConfirmed) {
                return;
            }
          });
    }




}




