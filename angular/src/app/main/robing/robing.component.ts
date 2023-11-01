import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { GridParams, PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { MstWptWorkingTimeDto, MstWptWorkingTimeServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng';

@Component({
    selector: 'robing',
    templateUrl: './robing.component.html',
    styleUrls: ['./robing.component.less'],
})
export class RobingComponent extends AppComponentBase implements OnInit {
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    rowdata = ['1','2','3','4','5','6','7','8','9','10','11','12']
    selectedDiv: any;

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
    onchangeSelection(item){
        if (this.selectedDiv === item) {
            this.selectedDiv = null;
          } else {
            this.selectedDiv = item;
          }
    }



    }




