import { EditDataComponent } from './editdata-form/editdata-form.component';
import { PatientsWorkingComponent } from './patients-working.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SaveAddPattientComponent } from './save-or-addpatient/save-or-addpat.component';

const routes: Routes = [
    {
        path: '',
        component: PatientsWorkingComponent,
        children: [
        {
          path: '',
          redirectTo: 'patients',
          pathMatch: 'full',
        },
        {
            path: "patients",
            component: SaveAddPattientComponent,
        },
        {
          path: "edit/:patientId",
          component: EditDataComponent,
      },
      ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PatientsWorkingRoutingModule {}
