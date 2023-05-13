import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DevaningContModuleServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-devaningScreen',
  templateUrl: './devaningScreen.component.html',
  styleUrls: ['./devaningScreen.component.less']
})
export class DevaningScreenComponent extends AppComponentBase implements OnInit {

  rowdata;
  process: number = 5;
  caseNo1: String = "DVN001";
  caseNo2: String = "DVN002";
  dateNow;
  arrayTest: any[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

  constructor(
    injector: Injector,
    private _service: DevaningContModuleServiceProxy,
  ) {
    super(injector)
  }

  ngOnInit() {
    this.fornumbersRange();
    this.loadFormData();
    this.getDataScreen();
  }
  ngAfterViewInit() {
    setInterval(() => {
      this.getTimeNow();
    }, 1000);
    console.log('ngAfterViewInit');
  }

  ngOnDestroy(): void {
    // clearTimeout(this.clearTimeLoadData);
  }


  fornumbersRange() {
    let numRange: number[] = [];
    for (let i = 1; i <= 5; i++) {
      numRange.push(i);
    }
    return numRange;
  }
  fornumbersProcess() {
    let numRange: number[] = [];
    for (let i = 1; i <= 40; i++) {
      numRange.push(i);
    }
    return numRange;
  }

  getTimeNow() {
    const d = new Date();
    const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    this.dateNow = (((d.getHours() + "").length == 1) ? ("0" + d.getHours()) : d.getHours()) + " : " + (((d.getMinutes() + "").length == 1) ? ("0" + d.getMinutes()) : d.getMinutes()) + " : " + (((d.getSeconds() + "").length == 1) ? ("0" + d.getSeconds()) : d.getSeconds()) + " ( " + (((month[d.getMonth()] + "").length == 1) ? ("0" + month[d.getMonth()]) : month[d.getMonth()]) + " - " + (((d.getDay() + "").length == 1) ? ("0" + d.getDay()) : d.getDay()) + " ) "
  }

  getDataScreen() {
    this._service.getDevaning()
      .subscribe((result) => {
        this.rowdata = result;
        console.log(this.rowdata);
      });

  }
  loadFormData() {
    // var widthScreen = window.innerWidth;
    // var widthProcessItem = widthScreen / (this.arrayTest.length)
    // console.log(this.arrayTest.length);


    // var processitem = document.querySelectorAll<HTMLElement>('.plan_actual_item')
    // for (let i = 0; processitem[i]; i++) {
    //   processitem[i].style.width = widthProcessItem + "px";
    // }
  }

}
