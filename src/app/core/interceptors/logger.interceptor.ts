import { HttpInterceptorFn } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';

export const loggerInterceptor: HttpInterceptorFn = (req, next) => {
  console.log('HTTP Request:', req);

  return next(req).pipe(
    tap(event => {
      if (event instanceof HttpResponse) {
        console.log('HTTP Response:', event);
      }
    })
  );
};
