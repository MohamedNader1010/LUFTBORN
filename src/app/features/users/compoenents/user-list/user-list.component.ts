
import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import { HasPermissionDirective } from '../../../../shared/directives/has-permission.directive';
import { Permissions } from '../../../../core/constants/permissions';


@Component({
  selector: 'lb-users-list',
  standalone: true,
  imports: [CommonModule, RouterLink, HasPermissionDirective],
  templateUrl: './user-list.component.html',
})
export class UsersListComponent implements OnInit {
  private userService = inject(UserService);
  private toastr = inject(ToastrService);
  public permissions = Permissions;

  users = signal<User[]>([]);
  loading = signal(true);

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.loading.set(true);
    this.userService.getAll().subscribe({
      next: (users) => {
        this.users.set(users);
        this.loading.set(false);
      },
      error: () => {
        this.toastr.error('Failed to load users');
        this.loading.set(false);
      },
    });
  }

  deleteUser(id: string): void {
    if (!confirm('Delete this user?')) return;

    this.userService.delete(id).subscribe({
      next: () => {
        this.toastr.success('User deleted');
        this.users.update((list) => list.filter((u) => u.id !== id));
      },
      error: () => this.toastr.error('Failed to delete user'),
    });
  }
}