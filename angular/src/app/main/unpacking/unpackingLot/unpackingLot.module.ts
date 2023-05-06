import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { TableModule } from 'primeng';
import { UnpackingLotRoutingModule } from './unpackingLot-routing.module';
import { UnpackingLotComponent } from './unpackingLot.component';

@NgModule({
    declarations: [
        UnpackingLotComponent,
    ],
    imports: [
        TableModule,
        UnpackingLotRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})
export class  UnpackingLotModule {}




