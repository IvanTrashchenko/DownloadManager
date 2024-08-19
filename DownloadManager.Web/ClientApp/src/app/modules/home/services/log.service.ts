import { Inject, Injectable } from '@angular/core';
import { Observable, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LogEntry } from '../models/log.model';

@Injectable({
    providedIn: 'root'
})
export class LogService {
    private apiUrl;

    constructor(private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.apiUrl = baseUrl + 'api/logs';
    }

    getLogs(): Observable<LogEntry[]> {
        return timer(0, 1000).pipe(
            switchMap(() => {
                const authToken = localStorage.getItem('auth_token') || '';
                const headers = new HttpHeaders().set('Authorization', `Bearer ${authToken}`);
                return this.http.get<LogEntry[]>(this.apiUrl, { headers: headers });
            })
        );
    }

    clear(): Observable<any> {
        const authToken = localStorage.getItem('auth_token') || '';
        const headers = new HttpHeaders().set('Authorization', `Bearer ${authToken}`);
        return this.http.delete(this.apiUrl, { headers: headers });
    }
}
