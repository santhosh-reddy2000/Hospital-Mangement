import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeadOfficeComponent } from './head-office/head-office.component';
import { DoctorDetailsComponent } from './doctor-details/doctor-details.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { AdminComponent } from './admin.component';

import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared-module/shared.module';
import { BranchOfficeComponent } from './branch-office/branch-office.component';

const routes: Routes = [
  { path: '', component: AdminComponent },
  
];

@NgModule({
  declarations: [
    AdminComponent,
    HeadOfficeComponent,
    BranchOfficeComponent,
    DoctorDetailsComponent,
    PatientDetailsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)  
  ]
})
export class AdminModule { }
