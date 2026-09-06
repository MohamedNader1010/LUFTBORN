import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { SidebarService } from '../../services/sidebar.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ThemeToggleButtonComponent } from '../../../shared/components/theme-toggle-button/theme-toggle-button.component';
import { LanguageSwitcherComponent } from '../../../shared/components/language-switcher/language-switcher.component';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { AccessService } from '../../../core/services/access-service.service';
@Component({
  selector: 'lb-header',
  imports: [
    CommonModule,
    RouterModule,
    ThemeToggleButtonComponent,
    LanguageSwitcherComponent
  ],
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  isApplicationMenuOpen = false;
  readonly isMobileOpen$;

  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;
  accessService = inject(AccessService);

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(result => {
      this.accessService.initFromCheckAuthResult(result);
    });

  }

  login() {
    this.oidcSecurityService.authorize();

  }

  logout() {
    this.oidcSecurityService.logoff().subscribe();
  }
  constructor(public sidebarService: SidebarService, private oidcSecurityService: OidcSecurityService) {
    this.isMobileOpen$ = this.sidebarService.isMobileOpen$;
  }

  handleToggle() {
    if (window.innerWidth >= 1280) {
      this.sidebarService.toggleExpanded();
    } else {
      this.sidebarService.toggleMobileOpen();
    }
  }

  toggleApplicationMenu() {
    this.isApplicationMenuOpen = !this.isApplicationMenuOpen;
  }

  ngAfterViewInit() {
    document.addEventListener('keydown', this.handleKeyDown);
  }

  ngOnDestroy() {
    document.removeEventListener('keydown', this.handleKeyDown);
  }

  handleKeyDown = (event: KeyboardEvent) => {
    if ((event.metaKey || event.ctrlKey) && event.key === 'k') {
      event.preventDefault();
      this.searchInput?.nativeElement.focus();
    }
  };
}
