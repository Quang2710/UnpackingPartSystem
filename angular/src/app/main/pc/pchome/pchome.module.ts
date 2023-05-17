import { NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { CommonModule } from '@angular/common';
import { PcHomeComponent } from './pchome.component';
import { PcHomeRoutingModule } from './pchome-routing.module';

@NgModule({
    declarations: [
        PcHomeComponent,
    ],
    imports: [
        CommonModule,
        PcHomeRoutingModule,
        //AppSharedModule,
    ]
})
export class PcHomeModule { }




