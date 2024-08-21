import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { AuthModel } from '../../auth/models/auth.model';
import * as jwt_decode from 'jwt-decode';

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
    return !!this.authToken && !this.isTokenExpired();
  }  

  private setAuthToken(value: string) {
    localStorage.setItem('auth_token', value);
  }

  public get authToken(): string {
    return localStorage.getItem('auth_token');
  }

  public get username(): string | null {
    const token = this.authToken;
    if (token) {
      const decodedToken = jwt_decode.jwtDecode<any>(token);
      return decodedToken?.unique_name || null;
    }
    return null;
  }

  login(model: AuthModel): Observable<any> {
    return this.post('login', model).pipe(
      tap((response: any) => {
        this.setAuthToken(response.Token);
      }),
      catchError((error) => {
        console.log(error);
        return throwError(error);
      })
    );
  }

  register(model: AuthModel): Observable<any> {
    return this.post('register', model).pipe(
      tap((response: any) => {
        this.setAuthToken(response.Token);
      }),
      catchError((error) => {
        console.log(error);
        return throwError(error);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('auth_token');
  }

  public isTokenExpired(): boolean {
    const token = this.authToken;
    if (token) {
      const decodedToken = jwt_decode.jwtDecode<any>(token);
      const expirationDate = new Date(0);
      expirationDate.setUTCSeconds(decodedToken.exp);
      return expirationDate < new Date();
    }
    return true;
  }
}
