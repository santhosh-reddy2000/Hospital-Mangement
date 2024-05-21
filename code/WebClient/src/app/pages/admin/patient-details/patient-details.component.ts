import { Component } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrl: './patient-details.component.less'
})
export class PatientDetailsComponent {

  patientDetailsForm: FormGroup<{
    doctorNamelist: FormControl<string>;
    PatientName: FormControl<string>;
    Age: FormControl<number>;
    RegistrationDate: FormControl<number>;
    Reasonforvist: FormControl<string>;
    Address: FormControl<string>;
    MobileNumber: FormControl<number>;
    email: FormControl<string>;
    languageKnow: FormControl<string>;
    Gender: FormControl<string>;
    BloodGroup: FormControl<string>;
    maritalStatus: FormControl<string>;
  }>;
  submitForm(): void {
    if (this.patientDetailsForm.valid) {
      const doctorDetailsFormList = {

        doctorNamelist: this.patientDetailsForm.value.doctorNamelist,
        PatientName: this.patientDetailsForm.value.PatientName,
        Age: this.patientDetailsForm.value.Age,
        RegistrationDate: this.patientDetailsForm.value.RegistrationDate,
        Reasonforvist: this.patientDetailsForm.value.Reasonforvist,
        Address: this.patientDetailsForm.value.Address,
        MobileNumber: this.patientDetailsForm.value.MobileNumber,      
        email: this.patientDetailsForm.value.email,
        languageKnow: this.patientDetailsForm.value.languageKnow,
        Gender: this.patientDetailsForm.value.Gender,
        BloodGroup: this.patientDetailsForm.value.BloodGroup,
        maritalStatus: this.patientDetailsForm.value.maritalStatus,
        

      };
      this._commonService.patientDetailsFormData.push(doctorDetailsFormList);
      this.patientDetailsForm.reset();
      console.log('submit', this._commonService.patientDetailsFormData);
    } else {
      console.log("Error occured")
    }
  }
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.patientDetailsForm.reset();
  }
  constructor(private fb: FormBuilder,public _commonService: CommonService) {
    this.patientDetailsForm = this.fb.group({
      doctorNamelist: ['', [Validators.required]],
      PatientName: ['', [Validators.required]],
      Age: [0, [Validators.required,,Validators.pattern('^\\d{2}$')]],
      RegistrationDate: [0, [Validators.required]],
      Reasonforvist: ['', [Validators.required]], 
      Address: ['', [Validators.required]],
      MobileNumber: [0, [Validators.required,Validators.pattern('^\\d{10}$')]], 
      email: ['', [Validators.email,Validators.required]],
      languageKnow: ['', [Validators.required]],
      Gender: ['', [Validators.required]],
      BloodGroup: ['', [Validators.required]],
      maritalStatus: ['', [Validators.required]],
    });
  }
 
  
}
