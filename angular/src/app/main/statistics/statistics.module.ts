import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { StatisticsRoutingModule } from './statistics-routing.module';
import { TableModule } from 'primeng';
import { StatisticsComponent } from './statistics.component';

@NgModule({
    declarations: [
        StatisticsComponent,
    ],
    imports: [
        TableModule,
        StatisticsRoutingModule,

        //AppSharedModule,
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})

export class StatisticsModule { }




