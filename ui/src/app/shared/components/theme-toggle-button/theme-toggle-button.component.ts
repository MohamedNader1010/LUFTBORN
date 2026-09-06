import { Component, inject } from '@angular/core';
import { ThemeService } from '../../services/theme.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lb-theme-toggle-button',
  imports: [CommonModule],
  templateUrl: './theme-toggle-button.component.html',
  styles: ``,
})
export class ThemeToggleButtonComponent {
  private _themeService = inject(ThemeService);
  theme$;


  constructor() {
    this.theme$ = this._themeService.theme$;
  }

  toggleTheme() {
    this._themeService.toggleTheme();
  }
}
