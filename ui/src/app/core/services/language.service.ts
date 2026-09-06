import { Injectable, signal, effect } from '@angular/core';

export type Language = 'en' | 'ar';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private readonly STORAGE_KEY = 'app-language';
  
  // Get initial language from localStorage or default to 'en'
  private getInitialLanguage(): Language {
    if (typeof window !== 'undefined' && window.localStorage) {
      const stored = localStorage.getItem(this.STORAGE_KEY);
      return (stored === 'ar' || stored === 'en') ? stored : 'en';
    }
    return 'en';
  }
  
  language = signal<Language>(this.getInitialLanguage());
  direction = signal<'ltr' | 'rtl'>(this.getInitialLanguage() === 'ar' ? 'rtl' : 'ltr');
  
  constructor() {
    // Sync direction with language changes
    effect(() => {
      const lang = this.language();
      const dir = lang === 'ar' ? 'rtl' : 'ltr';
      this.direction.set(dir);
      
      // Update document (only in browser environment)
      if (typeof document !== 'undefined') {
        document.documentElement.dir = dir;
        document.documentElement.lang = lang;
      }
      
      // Save to localStorage
      if (typeof window !== 'undefined' && window.localStorage) {
        localStorage.setItem(this.STORAGE_KEY, lang);
      }
    });
  }
  
  /**
   * Set the application language
   * @param lang - 'en' for English or 'ar' for Arabic
   */
  setLanguage(lang: Language): void {
    this.language.set(lang);
  }
  
  /**
   * Toggle between English and Arabic
   */
  toggleLanguage(): void {
    const newLang = this.language() === 'en' ? 'ar' : 'en';
    this.setLanguage(newLang);
  }
  
  /**
   * Check if current language is RTL (Arabic)
   */
  isRTL(): boolean {
    return this.language() === 'ar';
  }
  
  /**
   * Check if current language is Arabic
   */
  isArabic(): boolean {
    return this.language() === 'ar';
  }
  
  /**
   * Check if current language is English
   */
  isEnglish(): boolean {
    return this.language() === 'en';
  }
  
  /**
   * Get translated text based on current language
   * @param translations - Object with 'en' and 'ar' keys
   * @returns Translated text for current language
   */
  translate(translations: { en: string; ar: string }): string {
    return translations[this.language()];
  }
}