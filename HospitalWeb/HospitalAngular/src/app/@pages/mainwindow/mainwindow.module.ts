import { NbAuthService } from '@nebular/auth';
import { Router } from '@angular/router';
import { NgModule, OnInit } from '@angular/core';

import {
  NbCardModule,
  NbButtonModule,
  NbLayoutComponent,
  NbLayoutModule,
  NbThemeModule,
  NbUserModule,
} from '@nebular/theme';
import { MainWindowComponent } from './mainwindow.component';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    NbThemeModule,
    NbCardModule,
    NbButtonModule,
    NbLayoutModule,
    CommonModule,
    NbUserModule,
  ],
  exports: [MainWindowComponent],
  declarations: [MainWindowComponent],
  providers: [],
})
export class MainWindowModule {}
