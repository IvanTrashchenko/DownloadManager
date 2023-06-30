import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '../material/material.module';
import { AuthGuard } from './guards/auth.guard';


@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
  ],
  exports: [
    SpinnerComponent,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule
  ],
  providers: [
    AuthGuard
  ]
})
export class SharedModule { }
