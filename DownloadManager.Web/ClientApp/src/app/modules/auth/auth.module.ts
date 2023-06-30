import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthService } from './services/auth.service';
import { RegisterComponent } from './components/register/register.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    AuthRoutingModule,
    SharedModule,
    CommonModule
  ],
  providers: [
    AuthService
  ]
})
export class AuthModule { }
