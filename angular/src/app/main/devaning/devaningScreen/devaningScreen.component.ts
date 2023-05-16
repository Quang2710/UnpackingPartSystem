import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DevaningContModuleServiceProxy } from '@shared/service-proxies/service-proxies';
import * as $ from 'jquery';

// $(document).ready(function () {
//   $('.caseNo').hover(
//     function () {
//       $(this).text('FINISH');
//     },
//     function () {
//       var originalValue = $(this).data('case');
//       $(this).text(originalValue);
//     }
//   );
// });
@Component({
  selector: 'app-devaningScreen',
  templateUrl: './devaningScreen.component.html',
  styleUrls: ['./devaningScreen.component.less']
})


export class DevaningScreenComponent extends AppComponentBase implements OnInit {


  counT_DEVANING;
  id;
  rowdata;
  devaningPlan;
  containerCurren;
  containerNext;
  containerNameCurrent;
  containerNameNext;
  renbanCurent;
  renbanNext;
  currentId;
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
    //this.loadFormData();
    // this.getDevaningPlan();
    // this.getDataScreen();
  }
  ngAfterViewInit() {
    this.getDevaningPlan();
    setInterval(() => {
      this.getTimeNow();
    }, 1000);
    console.log('ngAfterViewInit');
  }

  ngOnDestroy(): void {
    // clearTimeout(this.clearTimeLoadData);
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
  } containerNo

  // Get Devaning Plan in Day

  getDevaningPlan() {
    this._service.getDevaningPlan()
      .subscribe((result) => {
        this.devaningPlan = result;
        this.containerCurren = this.devaningPlan.filter(item => item.status === 'DEVANING')[0];
        this.containerNameCurrent = this.containerCurren.container;
        this.renbanCurent = this.containerCurren.renban;
        this.currentId = this.containerCurren.id;

        this.containerNext = this.devaningPlan.filter(item => item.status === 'READY')[0];
        this.containerNameNext = this.containerNext.container;
        this.renbanNext = this.containerNext.renban;

      });
  }

  fornumbersRange() {
    let numRange: number[] = [];
    for (let i = 1; i <= this.devaningPlan; i++) {
      numRange.push(i);
    }
    return numRange;
  }


  finishDevModule(id: number) {
    this.message.confirm(this.l(''), 'FINISH CONTAINER CURRENT', (isConfirmed) => {
      if (isConfirmed) {
        this._service.finishDvnCont(id)
          .subscribe(() => {
            this.notify.success(this.l('FINISH Successfully '));
            this.getDevaningPlan();
            // this.getDataScreen();
          });
      }
    });
  }
  checkStatusContainer(status: string): string {
    if (status === 'DEVANED') {
      return 'DEVANED';
    } else if (status === 'DEVANING') {
      return 'DEVANING';
    } else if (status === 'READY') {
      return 'READY';
    }
  }
}
