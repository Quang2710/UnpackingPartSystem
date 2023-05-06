import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { DevaningContComponent } from './devaningCont.component';


const routes: Routes = [{
    path: '',
    component: DevaningContComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DevaningContRoutingModule {}
