import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private titleService: Title) { }

  ngOnInit(): void {
    this.titleService.setTitle('Login');
    this.initForm();
  }

  initForm(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.authService.login(this.loginForm.value).subscribe(
      (response) => {
        this.errorMessage = null;
        this.router.navigate(['/app']);
      },
      (error) => {
        if (error.status === 401 || error.status === 400) {
          // Handle 401 error. This typically means the username or password was incorrect.
          this.errorMessage = 'Invalid username or password.';
        } else if (error.status === 500) {
          // Handle 500 error. This typically means there was a server error.
          this.errorMessage = 'An error occurred on the server. Please try again later.';
        } else {
          // Handle all other errors.
          this.errorMessage = 'An unknown error occurred. Please try again.';
        }
      }
    );
  }
}