import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { UnpackingScreenComponent } from './unpackingScreen.component';


const routes: Routes = [{
    path: '',
    component: UnpackingScreenComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UnpackingScreenRoutingModule {}
