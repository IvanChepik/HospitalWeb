import { AuthGuard } from './../@auth/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { MainWindowComponent } from './mainwindow/mainwindow.component';
import { SaveAddPattientComponent } from './patients-working/save-or-addpatient/save-or-addpat.component';


const routes: Routes = [
  //   {
  //     //canActivate: [AuthGuard],
  //     path:'list-manager',
  //     loadChildren: () => import('src/app/pages/list-manager/module/list-manager.module')
  //       .then(m => m.ListManagerModule),
  //   },
  //   {
  //     canActivate: [AuthGuard],
  //     path:'organization',
  //     loadChildren: () => import('src/app/pages/organization-components/organization-page.module')
  //       .then(m => m.OrganizationPageModule),
  //   },
  {
    path: '',
    component: MainWindowComponent,
    pathMatch: 'full',
  },
  {
    canActivate: [AuthGuard],
    path: 'patients',
    loadChildren: () => import('src/app/@pages/patients-working/patients-working.module')
         .then(m => m.PatientWorkingModule),
  },
  //     path: "user-info",
  //     component: UserProfileComponent,
  //   },
  //   {
  //     path: "privacy-policy",
  //     component: PrivacyPageComponent,
  //   },
  //   {
  //     path: "no-permission",
  //     component: NoPermissionComponent,
  //   },
  //   {
  //     path: "no-auth",
  //     component: NoAutenticatedForm,
  //   },
  //   {
  //     path: "invite",
  //     component: InviteFormComponent,
  //   },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
