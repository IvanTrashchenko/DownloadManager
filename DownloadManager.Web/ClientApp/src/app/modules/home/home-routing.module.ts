import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';
import { DownloadComponent } from './components/download/download.component';
import { HomeComponent } from './components/home/home.component';
import { ReportsComponent } from './components/reports/reports.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard], children: [
      { path: 'download', component: DownloadComponent },
      { path: 'reports', component: ReportsComponent },
      { path: '', redirectTo: 'download', pathMatch: 'full' }
    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
