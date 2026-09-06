import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AccessService } from '../services/access-service.service';

export const permissionGuard = (requiredPermission: string): CanActivateFn => () => {
  const accessService = inject(AccessService);
  const router = inject(Router);

  if (accessService.hasPermission(requiredPermission)) {
    return true;
  }

  router.navigate(['/unauthorized']);
  return false;
};