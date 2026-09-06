// src/app/core/services/access.service.ts
import { Injectable, signal, inject } from '@angular/core';
import { OidcSecurityService, LoginResponse } from 'angular-auth-oidc-client';

@Injectable({ providedIn: 'root' })
export class AccessService {
  private oidcSecurityService = inject(OidcSecurityService);

  isAuthenticated = signal(false);
  userData = signal<any>(null);
  roles = signal<string[]>([]);
  permissions = signal<string[]>([]);

  initFromCheckAuthResult(result: LoginResponse): void {
    this.isAuthenticated.set(result.isAuthenticated);
    this.userData.set(result.userData ?? null);

    const payload = result.userData ?? null;
    this.oidcSecurityService.getPayloadFromAccessToken(false).subscribe(accessPayload => {
      this.roles.set(accessPayload?.['realm_access']?.roles ?? []);
      this.permissions.set(accessPayload?.['permissions'] ?? []);
    });
  }

  login(): void {
    this.oidcSecurityService.authorize();
  }

  logout(): void {
    this.oidcSecurityService.logoff().subscribe(() => {
      this.isAuthenticated.set(false);
      this.userData.set(null);
      this.roles.set([]);
      this.permissions.set([]);
    });
  }

  hasRole(role: string): boolean {
    return this.roles().includes(role);
  }

  hasPermission(permission: string): boolean {
    return this.permissions().includes(permission);
  }
}