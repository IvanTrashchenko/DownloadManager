import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { BaseService } from '../../shared/services/base.service';
import { AuthModel } from '../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {
  public authHeader: string;

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl, 'api/users/');
  }

  login(model: AuthModel): Observable<any> {
    return this.post('login', model).pipe(
      tap((response) => {
        if (response) {
          this.authHeader = 'Basic ' + btoa(model.username + ':' + model.password);
        }
      }),
      catchError((error) => {
        return throwError(error);
      })
    );
  }
}
