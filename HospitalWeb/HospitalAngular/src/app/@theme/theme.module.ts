import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  NbActionsModule,
  NbLayoutModule,
  NbMenuModule,
  NbSearchModule,
  NbSidebarModule,
  NbUserModule,
  NbContextMenuModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbSpinnerModule,
  NbThemeModule,
  NbListModule,
  NbInputModule,
  NbCardModule,
  NbTabsetModule,
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbSecurityModule } from '@nebular/security';



import {
  CapitalizePipe,
  PluralPipe,
  RoundPipe,
  TimingPipe,
  NumberWithCommasPipe,
} from './pipes';

import { InitUserService } from './services/init-user.service';

import { DEFAULT_THEME } from './styles/theme.default';
import { COSMIC_THEME } from './styles/theme.cosmic';
import { CORPORATE_THEME } from './styles/theme.corporate';
import { DARK_THEME } from './styles/theme.dark';
import { OneColumnLayoutComponent } from './layouts/one-column/one-column.layout';
import { ThreeColumnsLayoutComponent } from './layouts/three-columns/three-columns.layout';
import { TwoColumnsLayoutComponent } from './layouts/two-columns/two-columns.layout';
import { HeaderComponent, FooterComponent } from './components';

const NB_MODULES = [
  NbLayoutModule,
  NbMenuModule,
  NbUserModule,
  NbActionsModule,
  NbSearchModule,
  NbSidebarModule,
  NbContextMenuModule,
  NbSecurityModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbSpinnerModule,
  NbEvaIconsModule,
  NbMenuModule, 
  NbListModule, 
  NbInputModule,
  NbTabsetModule,
  NbCardModule
];

const LAYOUTS = [
  OneColumnLayoutComponent,
  ThreeColumnsLayoutComponent,
  TwoColumnsLayoutComponent,
  HeaderComponent,
  FooterComponent,
]

const PIPES = [
  CapitalizePipe,
  PluralPipe,
  RoundPipe,
  TimingPipe,
  NumberWithCommasPipe,
];

@NgModule({
  imports: [CommonModule,  ...NB_MODULES],
  exports: [CommonModule, ...PIPES, ...LAYOUTS, ...NB_MODULES],
  declarations: [...PIPES, ...LAYOUTS],
})
export class ThemeModule {
  static forRoot(): ModuleWithProviders<ThemeModule> {
    return {
      ngModule: ThemeModule,
      providers: [
        ...NbThemeModule.forRoot(
          {
            name: 'default',
          },
          [ DEFAULT_THEME, COSMIC_THEME, CORPORATE_THEME, DARK_THEME ],
        ).providers,
        InitUserService,
      ],
    };
  }
}
