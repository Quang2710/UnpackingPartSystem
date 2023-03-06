import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { WorkingtimeComponent } from './workingtime.component';


const routes: Routes = [{
    path: '',
    component: WorkingtimeComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class WorkingTimeRoutingModule {}
