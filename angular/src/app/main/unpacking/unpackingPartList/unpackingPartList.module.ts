import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { TableModule } from 'primeng';
import { UnpackingPartListRoutingModule } from './unpackingPartList-routing.module';
import { UnpackingPartListComponent } from './unpackingPartList.component';
import { DatePipe } from '@angular/common';
import { AppCommonModule } from '@app/shared/common/app-common.module';

@NgModule({
    declarations: [
        UnpackingPartListComponent,
    ],
    imports: [
        AppCommonModule,
        TableModule,
        UnpackingPartListRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ],
    providers: [DatePipe]
})
export class UnpackingPartListModule { }




