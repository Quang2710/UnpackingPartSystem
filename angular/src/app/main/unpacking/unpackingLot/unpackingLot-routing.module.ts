import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { UnpackingLotComponent } from './unpackingLot.component';


const routes: Routes = [{
    path: '',
    component: UnpackingLotComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UnpackingLotRoutingModule {}
