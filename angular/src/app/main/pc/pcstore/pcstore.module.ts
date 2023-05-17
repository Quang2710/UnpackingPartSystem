import { NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { CommonModule } from '@angular/common';
import { PcStoreComponent } from './pcstore.component';
import { PcStoreRoutingModule } from './pcstore-routing.module';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { TableModule } from 'primeng';

@NgModule({
    declarations: [
        PcStoreComponent,
    ],
    imports: [
        AppCommonModule,
        TableModule,
        CommonModule,
        PcStoreRoutingModule,
        //AppSharedModule,
    ]
})
export class PcStoreModule { }




