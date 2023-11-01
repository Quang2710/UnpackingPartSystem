import { Component, EventEmitter, Inject, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateOrEditDevaningContModuleDto, DevaningContModuleServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';


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
        private _service: DevaningContModuleServiceProxy,
    ) {
        super(injector);
    }
    partDetail;
    partName: string;
    supplier: string;

    ngOnInit() {
        console.log('partDetail',this.partDetail)
        this.partName = this.partDetail.partName
        this.supplier = this.partDetail.supplier
     }


     commit(): void {
        // this.saving = true;
        // this._service.createOrEdit(this.rowdata)
        //     .pipe(finalize(() => this.saving = false))
        //     .subscribe(() => {
        //         this.notify.info(this.l('Saved Successfully'));
        //         this.bsModalRef.hide();
        //         this.modalSave.emit(this.rowdata);
        //     });
        // this.saving = false;
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
    }

}
