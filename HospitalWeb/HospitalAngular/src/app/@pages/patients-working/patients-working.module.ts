import { EditDataModule } from './editdata-form/editdata.module';
import { ThemeModule } from './../../@theme/theme.module';
import { PatientsWorkingComponent } from './patients-working.component';

import { PatientsWorkingRoutingModule } from './patients-working-routing.module';

import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { SaveAddPattientComponent } from './save-or-addpatient/save-or-addpat.component';
import { SaveOrAddModule } from './save-or-addpatient/save-or-addpat.module';
import { NbSidebarModule } from '@nebular/theme';

@NgModule({
  imports: [
    PatientsWorkingRoutingModule,
    CommonModule,
    SaveOrAddModule,
    EditDataModule,
    ThemeModule,
    NbSidebarModule.forRoot(),
  ],
  exports: [],
  declarations: [PatientsWorkingComponent],
  providers: [],
})
export class PatientWorkingModule {}
