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
                        path: 'statistics',
                        loadChildren: () => import('./statistics/statistics.module').then(m => m.StatisticsModule),
                    },
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
                    {
                        path: 'unpacking/unpackingLot',
                        loadChildren: () => import('./unpacking/unpackingLot/unpackingLot.module').then(m => m.UnpackingLotModule),
                    },

                    {
                        path: 'unpacking/unpackingLot',
                        loadChildren: () => import('./unpacking/unpackingScreen/unpackingScreen.module').then(m => m.UnpackingScreenModule),
                    },

                    {
                        path: 'robing',
                        loadChildren: () => import('./robing/robing.module').then(m => m.RobingModule),
                    },
                    {
                        path: 'pc/pcstore',
                        loadChildren: () => import('./pc/pcstore/pcstore.module').then(m => m.PcStoreModule),
                    },
                    {
                        path: 'pc/home',
                        loadChildren: () => import('./pc/pchome/pchome.module').then(m => m.PcHomeModule),
                    },                

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
