import { HttpInterceptorFn } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError(err => {
      console.error('HTTP Error:', err);
      if (err.status === 401) {
        // I will redirect the user to login page.
      }
      return throwError(() => err);
    })
  );
};
