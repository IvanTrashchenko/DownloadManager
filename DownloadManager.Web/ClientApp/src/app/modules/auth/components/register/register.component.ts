import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../shared/services/auth.service';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { AuthModel } from '../../models/auth.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('Register');
    this.initForm();
  }

  initForm(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });
  }

  register(): void {
    this.errorMessage = null;

    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    let username = this.registerForm.controls.username.value;
    let password = this.registerForm.controls.password.value;
    let confirmPassword = this.registerForm.controls.confirmPassword.value;

    if (password !== confirmPassword) {
      this.errorMessage = "Passwords don't match."
      return;
    }

    let model: AuthModel = {
      username,
      password
    };

    this.authService.register(model).subscribe(
      (response) => {
        this.router.navigate(['/']);
      },
      (error) => {
        console.log(error);
        if (error.status === 409) {
          this.errorMessage = 'User with these credentials already exists.';
        } else if (error.status === 400) {
          this.errorMessage = 'Invalid username or password.';
        } else if (error.status === 500) {
          this.errorMessage = 'An error occurred on the server. Please try again later.';
        } else {
          this.errorMessage = 'An unknown error occurred. Please try again.';
        }
      }
    );
  }
}
