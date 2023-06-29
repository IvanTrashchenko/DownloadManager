import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

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
    private http: HttpClient,
    private router: Router) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login(): void {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe(
        (response) => {
          this.errorMessage = null;
          let username = this.loginForm.get('username')?.value;
          let password = this.loginForm.get('password')?.value;
          localStorage.setItem('authHeader', 'Basic ' + btoa(username + ':' + password));
          // later in service calls : const headers = new HttpHeaders({ Authorization:  localStorage.getItem('authHeader')});
          //maybe save as this.authenticationService.tokenValue.accessToken ?
          this.router.navigate(['/app']);
        },
        (error) => {
          // Handle error. You can set an error message to be displayed in the template.
          this.errorMessage = 'Invalid username or password.';
        }
      );
    }
    else {
      this.loginForm.markAllAsTouched();
    }
  }
}