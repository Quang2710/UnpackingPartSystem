import { NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { CommonModule } from '@angular/common';
import { PcStoreComponent } from './pcstore.component';
import { PcStoreRoutingModule } from './pcstore-routing.module';

@NgModule({
    declarations: [
        PcStoreComponent,
    ],
    imports: [
        CommonModule,
        PcStoreRoutingModule,
        //AppSharedModule,
    ]
})
export class PcStoreModule { }




