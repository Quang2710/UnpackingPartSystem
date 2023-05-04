import {NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import {  DevaningScreenRoutingModule } from './devaningScreen-routing.module';
import { DevaningScreenComponent } from './devaningScreen.component';

@NgModule({
    declarations: [
        DevaningScreenComponent,
    ],
    imports: [
        DevaningScreenRoutingModule,
        //AppSharedModule,
    ]
})
export class  DevaningScreenModule {}




