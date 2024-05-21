import { Component } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { ThemeService } from 'src/app/services/theme.service';
import { authService } from 'src/app/services/auth.service';
import { CommonService } from 'src/app/services/common.service';

type ThemeType = 'dark' | 'default' | 'blue' | 'green';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.less',

})

export class HeaderComponent {

  public environment = environment;
  selectedTheme: ThemeType = 'dark';

  themeOptions = [
    { label: 'Dark Theme', value: 'dark' },
    { label: 'Default Theme', value: 'default' },
    { label: 'Blue Theme', value: 'blue' },
    { label: 'Green Theme', value: 'green' },
  ];

  constructor(public _authService: authService,
    public _commonService: CommonService,
    private themeService: ThemeService,) {
  }

  updateSidebar() {
    this._commonService.isSidebarCollapsed = !this._commonService.isSidebarCollapsed
  }

  loadTheme() {
    this.themeService.currentTheme = this.selectedTheme as ThemeType;
    this.themeService.loadTheme();
  }

}