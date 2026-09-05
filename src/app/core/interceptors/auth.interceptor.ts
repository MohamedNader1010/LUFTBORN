import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { switchMap } from 'rxjs';

const KEYCLOAK_AUTHORITY = 'http://localhost:8081';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  if (req.url.startsWith(KEYCLOAK_AUTHORITY)) {
    return next(req);
  }

  const oidcSecurityService = inject(OidcSecurityService);

  return oidcSecurityService.getAccessToken().pipe(
    switchMap(token => {
      const cloned = token
        ? req.clone({ setHeaders: { Authorization: `Bearer ${token}` } })
        : req;
      return next(cloned);
    })
  );
};