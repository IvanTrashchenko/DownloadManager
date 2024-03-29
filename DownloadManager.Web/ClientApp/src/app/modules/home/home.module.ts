import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './components/home/home.component';
import { DownloadComponent } from './components/download/download.component';
import { ReportsComponent } from './components/reports/reports.component';


@NgModule({
  declarations: [
    HomeComponent,
    DownloadComponent,
    ReportsComponent
  ],
  imports: [
    HomeRoutingModule,
    CommonModule,
    SharedModule
  ]
})
export class HomeModule { }
