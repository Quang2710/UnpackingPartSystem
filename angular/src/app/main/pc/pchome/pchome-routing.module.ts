import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PcHomeComponent } from './pchome.component';


const routes: Routes = [{
    path: '',
    component: PcHomeComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PcHomeRoutingModule { }
