import { Component, Inject, Injector, OnInit, ViewChild } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';


@Component({
    selector: 'cre-devaningCont',
    templateUrl: './cre-devaningCont.component.html',
    styleUrls: ['./cre-devaningCont.component.less']
})
export class CreateEditDvnContComponent implements OnInit {

    constructor(
        public bsModalRef: BsModalRef,
        private injector: Injector
    ) { }

    ngOnInit() { }

    ngAfterViewInit() {
        const modalElement = document.querySelector('.modal-dialog');
        modalElement.classList.add('.modal-lg')
    }
    closeModal(): void {
        this.bsModalRef.hide();
    }

}
