import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RobingComponent } from './robing.component';


const routes: Routes = [{
    path: '',
    component: RobingComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class RobingRoutingModule { }
