import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DevaningContModuleServiceProxy, MstWptWorkingTimeDto, MstWptWorkingTimeServiceProxy, PcHomeServiceProxy, PcStoreServiceProxy, RobingServiceProxy, UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
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

    multi = [
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


    countContainer: number;
    countRobing : number;
    countModule : number;
    countPcStore : number;
    countPcHome : number;

    constructor(
        injector: Injector,
        private _devaningService: DevaningContModuleServiceProxy,
        private _robingService: RobingServiceProxy,
        private _unpackingService: UnpackingServiceProxy,
        private _pcStoreService: PcStoreServiceProxy,
        private _pcHomeService: PcHomeServiceProxy,
        private router: Router
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getContainer();
        this.getRobing();
        this.getModule();
        this.getPcStore();
        this.getPcHome();
    }
    openRoute(route) {
        if (route == 'dvnContainer') {
            this.router.navigate(['/app/main/devaning/devaningCont']);
        }
        else if (route == 'robing') {
            this.router.navigate(['/app/main/robing']);
        }
    }
    getContainer() {
        this._devaningService.getAll('','','','','','','')
            .subscribe((result) => {
                this.countContainer = result.length;
            });
    }
    getRobing(){
        this._robingService.getAllRobing('').subscribe((result) => {
            this.countRobing = result.length;
        });
    }
    getModule(){
        this._unpackingService.getAll('','','','','',).subscribe((result) => {
                this.countModule = result.length;
            });
    }
    getPcStore(){
        this._pcStoreService.getAll('','').subscribe((result) => {
            this.countPcStore = result.length;
        });
    }
    getPcHome(){
        this._pcHomeService.getAll('','').subscribe((result) => {
            this.countPcHome = result.length;
        });
    }

}




