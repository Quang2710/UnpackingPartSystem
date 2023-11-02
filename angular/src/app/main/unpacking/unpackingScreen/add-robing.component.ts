import { Component, EventEmitter, Inject, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateOrEditDevaningContModuleDto, DevaningContModuleServiceProxy, UnpackingServiceProxy } from '@shared/service-proxies/service-proxies';
import { error } from 'console';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { UnpackingScreenComponent } from './unpackingScreen.component';


@Component({
    selector: 'add-robing',
    templateUrl: './add-robing.component.html',
    styleUrls: ['./add-robing.component.less']
})
export class AddRobingComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Output() modalClose: EventEmitter<any> = new EventEmitter<any>();


    active: boolean = false;
    saving: boolean = false;
    rowdata: CreateOrEditDevaningContModuleDto = new CreateOrEditDevaningContModuleDto();

    constructor(
        public bsModalRef: BsModalRef,
        private injector: Injector,
        private _service: UnpackingServiceProxy,
        private unpackingScreen: UnpackingScreenComponent
    ) {
        super(injector);
    }
    partDetail;
    partName: string;
    supplier: string;
    type: string;
    description: string;

    disabled: boolean = true;

    ngOnInit() {
        console.log('partDetail',this.partDetail)
        this.partName = this.partDetail.partName
        this.supplier = this.partDetail.supplier
     }


     commit(): void {
        this._service.addPartToRobbing(
            this.partDetail.id,
            this.partDetail.partNo,
            this.partDetail.partName,
            this.partDetail.supplier,
            this.type,
            this.description
            )
        .subscribe(()=>{
            this.notify.success('Add Robbing success')
            this.closeModal()
            this.unpackingScreen.getModulePlan();
        },(error)=>{
            this.notify.error('Add Robbing Error',error)
        })
    }
    closeModal(): void {
        this.bsModalRef.hide();
    }
    setTypeRobing(type){
        var typeRobing = document.querySelectorAll('.rb-type')
        var selectionElement = document.querySelector('.' + type)
        typeRobing.forEach(function(element) {
            element.classList.remove('active')
        });
        selectionElement.classList.add('active')
        this.type = type
        this.disabled = false;
    }

}
