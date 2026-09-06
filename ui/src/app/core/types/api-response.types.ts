import { HttpStatusCode } from "@angular/common/http";

export interface ApiResponse<T> {
  Data?: T | null;
  Message: string;
  IsSuccess: boolean;
  StatusCode: HttpStatusCode
}