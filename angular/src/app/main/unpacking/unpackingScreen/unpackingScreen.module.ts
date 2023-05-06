import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { TableModule } from 'primeng';
import { UnpackingScreenComponent } from './unpackingScreen.component';
import { UnpackingScreenRoutingModule } from './unpackingScreen-routing.module';

@NgModule({
    declarations: [
        UnpackingScreenComponent,
    ],
    imports: [
        TableModule,
        UnpackingScreenRoutingModule,
        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})
export class  UnpackingScreenModule {}




