import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-doctor-details',
  templateUrl: './doctor-details.component.html',
  styleUrl: './doctor-details.component.less'
})
export class DoctorDetailsComponent {
  DoctorDetailsForm: FormGroup;
 
  constructor(private fb: FormBuilder,
      public _commonService: CommonService) {
      this.DoctorDetailsForm = this.fb.group({
        branchDetailList: ['', [Validators.required]],
        doctorName: ['', [Validators.required]],
        specialization: ['', [Validators.required]],
        Qulification: ['', [Validators.required]],
        country: ['', [Validators.required]],
        Address: ['', [Validators.required]],     
        MobileNumber: [, [Validators.required,Validators.pattern('^\\d{10}$')]],
        email: ['', [Validators.email,Validators.required]],
        languageKnow: ['', [Validators.required]],
        Gender: ['', [Validators.required]],
      });
    console.log("window.location", window.location)
  }
 
  ngOnInit(): void {
   
  }
  submitForm(): void {
    if (this.DoctorDetailsForm.valid) { 
      const doctorDetailsFormList = {

              branchDetailList: this.DoctorDetailsForm.value.branchDetailList,
              doctorName: this.DoctorDetailsForm.value.doctorName,
              specialization: this.DoctorDetailsForm.value.specialization,
              Qulification: this.DoctorDetailsForm.value.Qulification,
              country: this.DoctorDetailsForm.value.country,
              Address: this.DoctorDetailsForm.value.Address,
              MobileNumber: this.DoctorDetailsForm.value.MobileNumber,
              email: this.DoctorDetailsForm.value.email,
              languageKnow: this.DoctorDetailsForm.value.languageKnow,
              Gender: this.DoctorDetailsForm.value.Gender,
            }; 
     
        // Add new data
        this._commonService.doctorDetailsFormData.push(doctorDetailsFormList);     
      this.DoctorDetailsForm.reset();
      // this.isVisible = false;
     
    } else {
      console.log("Error occurred")
    }
  }
 
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.DoctorDetailsForm.reset();
  } 

}
