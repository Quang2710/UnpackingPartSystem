import {NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { DevaningContRoutingModule } from './devaningCont-routing.module';
import { DevaningContComponent } from './devaningCont.component';

@NgModule({
    declarations: [
        DevaningContComponent,
    ],
    imports: [
        DevaningContRoutingModule,
        //AppSharedModule,
    ]
})
export class  DevaningContModule {}




