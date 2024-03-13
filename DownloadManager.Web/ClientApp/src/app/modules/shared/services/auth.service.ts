import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { AuthModel } from '../../auth/models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl, 'api/users/');
  }

  public get isLoggedIn(): boolean {
    const header = localStorage.getItem('auth_header');
    if (header !== null) {
      return true;
    }
    return false;
  }

  public get auth_header(): string {
    return localStorage.getItem('auth_header');
  }

  private setAuthHeader(value: string) {
    localStorage.setItem('auth_header', value);
  }

  login(model: AuthModel): Observable<any> {
    return this.post('login', model).pipe(
      tap((response) => {
        let authHeader = 'Basic ' + btoa(model.username + ':' + model.password);
        this.setAuthHeader(authHeader);
      }),
      catchError((error) => {
        return throwError(error);
      })
    );
  }

  register(model: AuthModel): Observable<any> {
    return this.post('register', model).pipe(
      tap((response) => {
        let authHeader = 'Basic ' + btoa(model.username + ':' + model.password);
        this.setAuthHeader(authHeader);
      }),
      catchError((error) => {
        return throwError(error);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('auth_header');
  }
}
