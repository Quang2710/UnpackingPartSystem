import { Component, Injector, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { PaginationParamsModel } from '@app/shared/common/models/base.model';
import { GridTableService } from '@app/shared/common/services/grid-table.service';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DevaningContModuleDto, DevaningContModuleServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { Paginator } from 'primeng';
import { CreateEditDvnContComponent } from './cre-devaningCont.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DatePipe } from '@angular/common';
import { forEach } from 'lodash';

@Component({
    selector: 'app-devaningCont',
    templateUrl: './devaningCont.component.html',
    styleUrls: ['./devaningCont.component.less'],
})
export class DevaningContComponent extends AppComponentBase implements OnInit {

    statusBackground;
    indexShort: number = 0;
    filterText: string = '';
    isLoading;
    rowdata: any[] = [];
    selectedRowdata: DevaningContModuleDto = new DevaningContModuleDto();
    selectedRow: DevaningContModuleDto = new DevaningContModuleDto();
    data: DevaningContModuleDto = new DevaningContModuleDto();

    devaningNo: string = '';
    containerNo: string = '';
    renban: string = '';
    suppilerNo: string = '';
    shiftNo: string = '';
    workingDate;
    planDevaningDate;
    actDevaningDate;
    actDevaningDateFinish;
    devaningType: string = '';
    devaningStatus: string = '';
    bsModalRef: BsModalRef;

    constructor(
        injector: Injector,
        private _service: DevaningContModuleServiceProxy,
        private _fileDownloadService: FileDownloadService,
        private modalService: BsModalService,
    ) {
        super(injector)
    }

    ngOnInit() {
        this.getDatas();
    }

    getDatas() {
        this._service.getAll(
            this.devaningNo,
            this.containerNo,
            this.renban,
            this.suppilerNo,
            this.shiftNo,
            this.devaningType,
            this.devaningStatus
        )
            .subscribe((result) => {
                this.rowdata = result;

            });

    }
    clearTextSearch() {
        this.devaningNo = '';
        this.devaningStatus = '';
        this.getDatas();

    }
    deleteRow(system: DevaningContModuleDto): void {
        this.message.confirm(this.l('Are You Sure To Delete'), 'Delete Row', (isConfirmed) => {
            if (isConfirmed) {
                this._service.delete(system.id).subscribe(() => {
                    this.getDatas();
                    this.notify.success(this.l('Success fully Deleted'));
                });
            }

        });
    }

    exportToExcel(): void {
        this._service
            .getDevaningContModuleToExcel(
                this.devaningNo,
                this.containerNo,
                this.renban,
                this.suppilerNo,
                this.shiftNo,
                this.workingDate,
                this.planDevaningDate,
                this.actDevaningDate,
                this.actDevaningDateFinish,
                this.devaningType,
                this.devaningStatus,
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
                this.notify.success('Export success')

            },(error)=>{
                this.notify.error('Export failed',error)
            });
    }

    openModal() {
        this.bsModalRef = this.modalService.show(CreateEditDvnContComponent, {});
    }

    onRowSelect(event) {
        const devaningNo = event.data.devaningNo;
        console.log('Selected Devaning No: ', this.selectedRowdata);
    }

    getStatusBackgroundClass(status: string): string {
        if (status === 'DEVANED') {
            return 'DEVANED';
        } else if (status === 'DEVANING') {
            return 'DEVANING';
        } else if (status === 'READY') {
            return 'READY';
        }
    }

}
