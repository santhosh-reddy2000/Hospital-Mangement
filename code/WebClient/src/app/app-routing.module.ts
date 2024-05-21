
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OktaAuthGuard, OktaCallbackComponent } from '@okta/okta-angular';
import { environment } from 'src/environments/environment.development';
import { HeadOfficeComponent } from './pages/home/head-office/head-office.component';
import { BranchDetailsComponent } from './pages/home/branch-details/branch-details.component';
import { PatientDetailsComponent } from './pages/home/patient-details/patient-details.component';
import { DoctorDetailsComponent } from './pages/home/doctor-details/doctor-details.component';
import { AdminComponent } from './pages/admin/admin.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/home' },
  { path: 'home', canActivate: [OktaAuthGuard], loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule) },
  
  {
    path: 'login/callback',
    component: OktaCallbackComponent,
  }, 
];

const skipauthRoutes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/head-office' },
  { path: 'home', loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule) },
  
 
  {path: 'head-office', component:HeadOfficeComponent},
  {path: 'branch-office', component:BranchDetailsComponent},
  {path:'Patient-Details',component:PatientDetailsComponent},
  {path:'Doctor-Details',component:DoctorDetailsComponent},


  { path: 'admin', loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminModule) },



{ path:'admin-Details' ,loadChildren: () => import('./pages/admin-details/admin-details.module').then(m => m.AdminDetailsModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(environment.userauthentication ? routes : skipauthRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }