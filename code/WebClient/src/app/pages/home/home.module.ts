import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SharedModule } from '../../shared-module/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { HeadOfficeComponent } from './head-office/head-office.component';
import { BranchDetailsComponent } from './branch-details/branch-details.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { DoctorDetailsComponent } from './doctor-details/doctor-details.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  
];

@NgModule({
  declarations: [
    HomeComponent,
    HeadOfficeComponent,
    BranchDetailsComponent,
    PatientDetailsComponent,
    DoctorDetailsComponent,
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)  
  ]
})

export class HomeModule { }