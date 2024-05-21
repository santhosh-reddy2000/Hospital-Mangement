import { Injectable } from '@angular/core';

type ThemeType = 'dark' | 'default' | 'blue' | 'green';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  currentTheme: ThemeType = 'dark';

  constructor() {
    this.loadTheme()
  }

  private reverseTheme(theme: ThemeType): ThemeType {
    switch (theme) {
      case 'dark':
        return 'default';
      case 'default':
        return 'dark';
      case 'blue':
        return 'green';
      case 'green':
        return 'blue';
    }
  }

  private removeUnusedTheme(theme: ThemeType): void {
    document.documentElement.classList.remove(theme);
    const removedThemeStyle = document.getElementById(theme);
    if (removedThemeStyle) {
      document.head.removeChild(removedThemeStyle);
    }
  }

  private loadCss(href: string, id: ThemeType): Promise<void> {
    return new Promise((resolve, reject) => {
      const style = document.createElement('link');
      style.rel = 'stylesheet';
      style.href = href;
      style.id = id;

      style.onload = (event: Event) => resolve();
      style.onerror = (event: Event) => reject();

      document.head.append(style);
    });
  }

  private applyThemeToDocument(theme: ThemeType): void {
    document.documentElement.classList.add(theme);
  }

  private loadAndApplyTheme(theme: ThemeType): Promise<void> {
    return this.loadCss(`${theme}.css`, theme).then(() => {
      this.applyThemeToDocument(theme);
    });
  }

  private removeUnusedThemes(): void {
    const unusedTheme = this.reverseTheme(this.currentTheme);
    this.removeUnusedTheme(unusedTheme);
  }

  public loadTheme(firstLoad = true): Promise<void> {
    if (firstLoad) {
      this.applyThemeToDocument(this.currentTheme);
    }

    return this.loadAndApplyTheme(this.currentTheme).then(() => {
      if (!firstLoad) {
        this.removeUnusedThemes();
      }
    });
  }

  public toggleTheme(): Promise<void> {
    // Ensure the reverseTheme result is of type ThemeType
    this.currentTheme = this.reverseTheme(this.currentTheme) as ThemeType;
    return this.loadAndApplyTheme(this.currentTheme).then(() => {
      this.removeUnusedThemes();
    });
  }
}
