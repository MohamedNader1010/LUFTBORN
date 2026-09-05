import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout/main-layout.component';
import { permissionGuard } from './core/guards/permission.guard';
import { UsersListComponent } from './features/users/compoenents/user-list/user-list.component';
import { AddEditUserComponent } from './features/users/compoenents/add-edit-user/add-edit-user.component';
import { Permissions } from './core/constants/permissions';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'users',
        component: UsersListComponent,
        canActivate: [permissionGuard(Permissions.User.Get)],
      },
      {
        path: 'users/new',
        component: AddEditUserComponent,
        canActivate: [permissionGuard(Permissions.User.Create)],
      },
      {
        path: 'users/:id/edit',
        component: AddEditUserComponent,
        canActivate: [permissionGuard(Permissions.User.Update)],
      },
    ],
  },
];