import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    // {
                    //     path: 'master/workingpattern',
                    //     loadChildren: () => import('./master/workingpattern/dashborad-custome.module').then(m => m.DashBoradCustomeModule),
                    //  },
                    {
                        path: 'master/workingpattern/workingtime',
                        loadChildren: () => import('./master/workingpattern/workingtime/workingtime.module').then(m => m.WorkingTimeModule),
                     },
                    {
                        path: 'devaning/devaningCont',
                        loadChildren: () => import('./devaning/devaningCont/devaningCont.module').then(m => m.DevaningContModule),
                     },
                    {
                        path: 'devaning/devaningScreen',
                        loadChildren: () => import('./devaning/devaningScreen/devaningScreen.module').then(m => m.DevaningScreenModule),
                     },
                    // {
                    //     path: 'master/workingpattern',
                    //     loadChildren: () => import('./master/workingpatter/dashborad-custome.module').then(m => m.DashBoradCustomeModule),
                    //     data: { permission: 'Pages.Master.WorkingPattern' }
                    // },

                    { path: '**', redirectTo: 'dashboard' }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
