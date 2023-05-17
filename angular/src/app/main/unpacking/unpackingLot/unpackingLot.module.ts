import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { TableModule } from 'primeng';
import { UnpackingLotRoutingModule } from './unpackingLot-routing.module';
import { UnpackingLotComponent } from './unpackingLot.component';
import { DatePipe } from '@angular/common';
import { AppCommonModule } from '@app/shared/common/app-common.module';

@NgModule({
    declarations: [
        UnpackingLotComponent,
    ],
    imports: [
        AppCommonModule,
        TableModule,
        UnpackingLotRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ],
    providers: [DatePipe]
})
export class UnpackingLotModule { }




