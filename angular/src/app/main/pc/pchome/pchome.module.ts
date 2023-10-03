import { NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { CommonModule } from '@angular/common';
import { PcHomeComponent } from './pchome.component';
import { PcHomeRoutingModule } from './pchome-routing.module';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { TableModule } from 'primeng';

@NgModule({
    declarations: [
        PcHomeComponent,
    ],
    imports: [
        AppCommonModule,
        TableModule,
        CommonModule,
        CommonModule,
        PcHomeRoutingModule,
    ]
})
export class PcHomeModule { }




