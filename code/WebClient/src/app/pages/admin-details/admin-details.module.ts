import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDetailsComponent } from './admin-details.component';
import { RouterModule, Routes } from '@angular/router';
import { HeadOfficeDetailsComponent } from './head-office-details/head-office-details.component';
import { BranchOfficeDetailsComponent } from './branch-office-details/branch-office-details.component';
import { DoctorDetailsComponent } from './doctor-details/doctor-details.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { SharedModule } from 'src/app/shared-module/shared.module';

const routes: Routes =[
  { path:'',component:AdminDetailsComponent}
]

@NgModule({
  declarations: [
    AdminDetailsComponent,
    HeadOfficeDetailsComponent,
    BranchOfficeDetailsComponent,
    DoctorDetailsComponent,
    PatientDetailsComponent

 
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class AdminDetailsModule { }

