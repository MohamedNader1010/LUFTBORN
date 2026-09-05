import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiOptions } from '../types/api.types';
import { environment } from '../../environments/environment';
import { ApiResponse } from '../types/api-response.types';

@Injectable({
  providedIn: 'root',
})
export class BaseApiService<T> {
  private readonly BASE_URL = environment.apiUrl;

  constructor(protected http: HttpClient) { }

  private buildUrl(endpoint: string): string {
    return `${this.BASE_URL}/${endpoint.replace(/^\/+/, '')}`;
  }

  getAll(endpoint: string, options?: ApiOptions): Observable<ApiResponse<T[]>> {
    return this.http.get<ApiResponse<T[]>>(this.buildUrl(endpoint), { params: options?.params, headers: options?.headers });
  }

  getById(endpoint: string, id: string | number, options?: ApiOptions): Observable<ApiResponse<T>> {
    return this.http.get<ApiResponse<T>>(`${this.buildUrl(endpoint)}/${id}`, { params: options?.params, headers: options?.headers });
  }

  create(endpoint: string, data: Partial<T>, options?: ApiOptions): Observable<ApiResponse<T>> {
    return this.http.post<ApiResponse<T>>(this.buildUrl(endpoint), data, { params: options?.params, headers: options?.headers });
  }

  update(endpoint: string, id: string | number, data: Partial<T>, options?: ApiOptions): Observable<ApiResponse<T>> {
    return this.http.put<ApiResponse<T>>(`${this.buildUrl(endpoint)}/${id}`, data, { params: options?.params, headers: options?.headers });
  }

  delete(endpoint: string, id: string | number, options?: ApiOptions): Observable<ApiResponse<void>> {
    return this.http.delete<ApiResponse<void>>(`${this.buildUrl(endpoint)}/${id}`, { params: options?.params, headers: options?.headers });
  }

  upload(endpoint: string, files: File | File[], additionalData?: Record<string, any>): Observable<ApiResponse<T>> {
    const formData = new FormData();

    if (Array.isArray(files)) {
      files.forEach(file => formData.append('file', file));
    } else {
      formData.append('file', files);
    }

    if (additionalData) {
      Object.keys(additionalData).forEach(key => formData.append(key, additionalData[key]));
    }

    return this.http.post<ApiResponse<T>>(this.buildUrl(endpoint), formData);
  }
}
