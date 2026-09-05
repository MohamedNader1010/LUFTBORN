import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'lb-add-edit-user',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-edit-user.component.html',
  styles: ``,
})
export class AddEditUserComponent {
  private fb = inject(FormBuilder);
  private userService = inject(UserService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private toastr = inject(ToastrService);

  isEditMode = signal(false);
  userId = signal<string | null>(null);

  form = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: [''],
  });

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode.set(true);
      this.userId.set(id);
      this.form.get('password')?.clearValidators();

      this.userService.getById(id).subscribe({
        next: (user) => {
          this.form.patchValue({
            firstName: user.firstName,
            lastName: user.lastName,
            email: user.email,
          });
        },
        error: () => this.toastr.error('Failed to load user'),
      });
    } else {
      this.form.get('password')?.setValidators(Validators.required);
    }
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const { firstName, lastName, email, password } = this.form.getRawValue();

    if (this.isEditMode()) {
      this.userService
        .update(this.userId()!, {
          userId: this.userId()!,
          firstName: firstName!,
          lastName: lastName!,
          email: email!,
        })
        .subscribe({
          next: () => {
            this.toastr.success('User updated');
            this.router.navigate(['/users']);
          },
          error: () => this.toastr.error('Failed to update user'),
        });
    } else {
      this.userService
        .create({ firstName: firstName!, lastName: lastName!, email: email!, password: password! })
        .subscribe({
          next: () => {
            this.toastr.success('User created');
            this.router.navigate(['/users']);
          },
          error: () => this.toastr.error('Failed to create user'),
        });
    }
  }
}
