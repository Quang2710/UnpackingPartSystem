import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { TableModule } from 'primeng';
import { UnpackingScreenComponent } from './unpackingScreen.component';
import { UnpackingScreenRoutingModule } from './unpackingScreen-routing.module';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { DatePipe } from '@angular/common';

@NgModule({
    declarations: [
        UnpackingScreenComponent,
    ],
    imports: [
        AppCommonModule,
        TableModule,
        UnpackingScreenRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ],
    providers: [DatePipe]
})
export class UnpackingScreenModule { }




