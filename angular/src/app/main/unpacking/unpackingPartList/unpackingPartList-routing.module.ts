import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { UnpackingPartListComponent } from './unpackingPartList.component';


const routes: Routes = [{
    path: '',
    component: UnpackingPartListComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UnpackingPartListRoutingModule {}
