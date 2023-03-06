import {NgModule} from '@angular/core';
//import {AppSharedModule} from '@app/shared/app-shared.module';
import { WorkingTimeRoutingModule } from './workingtime-routing.module';
import { WorkingtimeComponent } from './workingtime.component';

@NgModule({
    declarations: [
        WorkingtimeComponent,
    ],
    imports: [
        WorkingTimeRoutingModule,
        //AppSharedModule,
    ]
})
export class  WorkingTimeModule {}




