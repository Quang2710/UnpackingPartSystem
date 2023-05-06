import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { DevaningContRoutingModule } from './devaningCont-routing.module';
import { DevaningContComponent } from './devaningCont.component';
import { TableModule } from 'primeng';

@NgModule({
    declarations: [
        DevaningContComponent,
    ],
    imports: [
        TableModule,
        DevaningContRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})
export class  DevaningContModule {}




