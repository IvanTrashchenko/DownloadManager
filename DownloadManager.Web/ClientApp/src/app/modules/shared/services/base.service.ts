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
        return this.httpClient.get<T>(`${this.baseApiUrl}${url}`, { params: params });
    }

    protected getFile(url: string, params: HttpParams | {} = null): Observable<any> {
        this.clearHttpParams(params);
        return this.httpClient.get(`${this.baseApiUrl}${url}`, { params: params, observe: 'response', responseType: 'blob' });
    }

    protected post<T>(url: string, model: any, params: any = null): Observable<T> {
        this.clearHttpParams(params);
        const body = JSON.stringify(model);
        const headers = { 'content-type': 'application/json' }
        const httpOptions = { headers: new HttpHeaders(headers), params: params };
        return this.httpClient.post<T>(`${this.baseApiUrl}${url}`, body, httpOptions);
    }

    protected put<T>(url: string, model: any, params: any = null): Observable<T> {
        this.clearHttpParams(params);
        const body = JSON.stringify(model);
        const headers = { 'content-type': 'application/json' }
        const httpOptions = { headers: new HttpHeaders(headers), params: params };
        return this.httpClient.put<T>(`${this.baseApiUrl}${url}`, body, httpOptions);
    }

    protected delete<T>(url: string, params: any = null): Observable<T> {
        this.clearHttpParams(params);
        return this.httpClient.delete<T>(`${this.baseApiUrl}${url}`, { params: params });
    }

    protected patch<T>(url: string, model: any, params: any = null): Observable<T> {
        this.clearHttpParams(params);
        const body = JSON.stringify(model);
        const headers = { 'content-type': 'application/json' }
        const httpOptions = { headers: new HttpHeaders(headers), params: params };
        return this.httpClient.patch<T>(`${this.baseApiUrl}${url}`, body, httpOptions);
    }

    private clearHttpParams(params: any): void {
        if (params !== null) {
            Object.keys(params).forEach(key => params[key] === undefined ? delete params[key] : {});
        }
    }
}
