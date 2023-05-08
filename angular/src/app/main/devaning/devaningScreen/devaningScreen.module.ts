import { NgModule } from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { DevaningScreenRoutingModule } from './devaningScreen-routing.module';
import { DevaningScreenComponent } from './devaningScreen.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        DevaningScreenComponent,
    ],
    imports: [
        CommonModule,
        DevaningScreenRoutingModule,
        //AppSharedModule,
    ]
})
export class DevaningScreenModule { }




