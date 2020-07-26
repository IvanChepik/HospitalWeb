import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NbThemeModule, NbLayoutComponent, NbLayoutModule, NbSidebarModule, NbMenuModule, NbDatepickerModule } from '@nebular/theme';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NbAuthJWTToken, NbAuthModule, NbPasswordAuthStrategy, NbTokenLocalStorage, NbTokenStorage } from '@nebular/auth';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { CoreModule } from './@core/core.module';
import { ThemeModule } from './@theme/theme.module';
import { AuthModule } from './@auth/auth.module';

const formSetting: any = {
  redirectDelay: 0,
  showMessages: {
    success: true,
  },
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    ThemeModule.forRoot(),
    CoreModule.forRoot(),
    FormsModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NbLayoutModule,
    
    NbDatepickerModule.forRoot(),
    NbEvaIconsModule,
    CoreModule.forRoot(),
    NbThemeModule.forRoot({ name: 'default' }),
    AuthModule.forRoot()
  ],
  providers: [
    { provide: NbTokenStorage, useClass: NbTokenLocalStorage },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
