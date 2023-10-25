import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
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

    // barChartData = [
    //     {
    //       name: 'Devaning',
    //       value: 25,
    //     },
    //     {
    //       name: 'Unpacking',
    //       value: 50,
    //     },
    //     {
    //       name: 'Pc Store',
    //       value: 75,
    //     },
    //     {
    //       name: 'Pc Home',
    //       value: 55,
    //     },
    //     {
    //       name: 'Robing',
    //       value: 75,
    //     },
    //     {
    //       name: 'Robing1',
    //       value: 55,
    //     },
    //   ];

    multi =  [
        {
          "name": "Devaning",
          "series": [
            {
              "name": "Plan",
              "value": 30
            },
            {
              "name": "Actual",
              "value": 25
            }
          ]
        },

        {
          "name": "Unpacking",
          "series": [
            {
              "name": "Plan",
              "value": 50
            },
            {
              "name": "Actual",
              "value": 25
            }
          ]
        },

        {
          "name": "Pc",
          "series": [
            {
              "name": "Plan",
              "value": 100
            },
            {
              "name": "Actual",
              "value": 10
            }
          ]
        }
      ];


      view: any[] = [,];

      // options
      showXAxis: boolean = true;
      showYAxis: boolean = true;
      gradient: boolean = true;
      showLegend: boolean = true;
      showXAxisLabel: boolean = true;
      xAxisLabel: string = 'Actual';
      showYAxisLabel: boolean = true;
      yAxisLabel: string = 'Plan';
      legendTitle: string = 'Time';

      colorScheme = {
        domain: ['#5AA454', '#C7B42C', '#AAAAAA'],
      };


    constructor(
        injector: Injector,
        private _service: MstWptWorkingTimeServiceProxy,
        private gridTableService: GridTableService,
        private router: Router
    ) {
        super(injector)
    }

    ngOnInit() {


    }
    openDvnContainer(){
        this.router.navigate(['/app/main/devaning/devaningCont']);
    }



    }




