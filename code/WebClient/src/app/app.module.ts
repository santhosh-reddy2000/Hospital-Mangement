import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment.development';
import { OKTA_CONFIG, OktaAuthModule } from '@okta/okta-angular';
import OktaAuth from '@okta/okta-auth-js';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptorService } from './services/TokenInterceptor.service';
import { HeaderComponent } from './layout/header/header.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { SharedModule } from './shared-module/shared.module';
import { registerLocaleData } from '@angular/common';






registerLocaleData(en);

const config = {
  issuer: environment.ISSUER,
  clientId: environment.CLIENT_ID,
  redirectUri: environment.LOGIN_REDIRECT_URI,
  scopes: environment.scopes,
  pkce: true
}

const oktaAuth = new OktaAuth(config);

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent,
    FooterComponent
 
   
   
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    OktaAuthModule,
    SharedModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    { provide: OKTA_CONFIG, useValue: { oktaAuth } },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }