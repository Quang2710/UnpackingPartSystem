import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { DevaningContRoutingModule } from './devaningCont-routing.module';
import { DevaningContComponent } from './devaningCont.component';
import { TableModule } from 'primeng';
import { DialogModule } from 'primeng/dialog';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CreateEditDvnContComponent } from './cre-devaningCont.component';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { DatePipe } from '@angular/common';

@NgModule({
    declarations: [
        DevaningContComponent,
        CreateEditDvnContComponent
    ],
    imports: [
        AppCommonModule,
        TableModule,
        DevaningContRoutingModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ],
    providers: [DatePipe]
})
export class DevaningContModule { }




