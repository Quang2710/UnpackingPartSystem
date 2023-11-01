import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { RobingRoutingModule } from './robing-routing.module';
import { RobingComponent } from './robing.component';
import { AppCommonModule } from '@app/shared/common/app-common.module';

@NgModule({
    declarations: [
        RobingComponent,
    ],
    imports: [
        RobingRoutingModule,
        AppCommonModule

    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA,
        NO_ERRORS_SCHEMA
    ]
})

export class RobingModule { }




