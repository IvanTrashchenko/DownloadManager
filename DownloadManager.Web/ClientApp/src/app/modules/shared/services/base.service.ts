import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BaseService {
    protected baseApiUrl: string;
    constructor(
        protected httpClient: HttpClient,
        baseUrl: string,
        endpointUrl: string,
    ) {
        this.baseApiUrl = baseUrl + endpointUrl;
    }

    protected get<T>(url: string, params: HttpParams | {} = null): Observable<T> {
        this.clearHttpParams(params);
        const authToken = localStorage.getItem('auth_token') || '';
        const headers = new HttpHeaders().set('Authorization', `Bearer ${authToken}`);
        return this.httpClient.get<T>(`${this.baseApiUrl}${url}`, { params: params, headers: headers });
    }
    
    protected post<T>(url: string, model: any, params: any = null): Observable<T> {
        this.clearHttpParams(params);
        const body = JSON.stringify(model);
        const authToken = localStorage.getItem('auth_token') || '';
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${authToken}`
        });
        const httpOptions = { headers: headers, params: params };
        return this.httpClient.post<T>(`${this.baseApiUrl}${url}`, body, httpOptions);
    }    

    private clearHttpParams(params: any): void {
        if (params !== null) {
            Object.keys(params).forEach(key => params[key] === undefined ? delete params[key] : {});
        }
    }
}
