import { Component, inject } from '@angular/core';
import { BackdropComponent } from '../backdrop/backdrop.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SidebarService } from '../../services/sidebar.service';
import { LanguageService } from '../../../core/services/language.service';


@Component({
  selector: 'lb-main-layout',
  imports: [CommonModule, RouterModule, HeaderComponent, SidebarComponent, BackdropComponent],
  templateUrl: './main-layout.component.html',
  styles: ``,
})
export class MainLayoutComponent {
  readonly isExpanded$;
  readonly isHovered$;
  readonly isMobileOpen$;

  langService = inject(LanguageService);

  private sidebarService = inject(SidebarService);
  constructor() {
    this.isExpanded$ = this.sidebarService.isExpanded$;
    this.isHovered$ = this.sidebarService.isHovered$;
    this.isMobileOpen$ = this.sidebarService.isMobileOpen$;
  }

  get containerClasses() {
    return [
      'flex-1',
      'transition-all',
      'duration-300',
      'ease-in-out',
      this.isExpanded$ || this.isHovered$ ? 'xl:ml-[290px]' : 'xl:ml-[90px]',
      this.isMobileOpen$ ? 'ml-0' : '',
      this.langService.isRTL() ? 'xl:flex-row-reverse' : '',
    ];
  }
}
