import { Component, inject } from '@angular/core';
import { LanguageService } from '../../../core/services/language.service';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, GlobeIcon } from 'lucide-angular';

@Component({
  selector: 'lb-language-switcher',
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './language-switcher.component.html',
  styles: ``,
})
export class LanguageSwitcherComponent {
  langService = inject(LanguageService);
  public readonly globIcon = GlobeIcon;
}
