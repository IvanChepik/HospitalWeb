import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NbAuthComponent, NbLoginComponent, NbRequestPasswordComponent, NbResetPasswordComponent, NbLogoutComponent } from '@nebular/auth';


const routes: Routes = [

  {
    path:'',
    loadChildren: () => import('src/app/@pages/pages.module')
      .then(m => m.PagesModule),
  },
  {
    path:'auth',
    loadChildren: () => import('src/app/@auth/auth.module')
      .then(m => m.AuthModule),
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
