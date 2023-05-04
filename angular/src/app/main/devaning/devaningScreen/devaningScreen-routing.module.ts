import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { DevaningScreenComponent } from './devaningScreen.component';


const routes: Routes = [{
    path: '',
    component: DevaningScreenComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DevaningScreenRoutingModule {}
