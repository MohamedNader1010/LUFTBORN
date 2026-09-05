import { HttpParams, HttpHeaders } from '@angular/common/http';

export interface ApiOptions {
  params?: HttpParams | { [param: string]: string | number | boolean };
  headers?: HttpHeaders;
}