import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { StatisticsRoutingModule } from './statistics-routing.module';
import { TableModule } from 'primeng';
import { StatisticsComponent } from './statistics.component';
import { AppCommonModule } from '@app/shared/common/app-common.module';

@NgModule({
    declarations: [
        StatisticsComponent,
    ],
    imports: [
        StatisticsRoutingModule,
        AppCommonModule

    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA,
        NO_ERRORS_SCHEMA
    ]
})

export class StatisticsModule { }




