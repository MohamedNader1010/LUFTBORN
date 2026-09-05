import { CommonModule } from '@angular/common';
import { SidebarService } from './../../services/sidebar.service';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'lb-backdrop',
  imports: [CommonModule],
  templateUrl: './backdrop.component.html',
  styles: ``,
})
export class BackdropComponent {
  readonly isMobileOpen$;
  private sidebarService = inject(SidebarService);
  constructor() {
    this.isMobileOpen$ = this.sidebarService.isMobileOpen$;
  }

  closeSidebar() {
    this.sidebarService.setMobileOpen(false);
  }
}
