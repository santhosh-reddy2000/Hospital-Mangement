import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-doctor-details',
  templateUrl: './doctor-details.component.html',
  styleUrl: './doctor-details.component.less'
})
export class DoctorDetailsComponent implements OnInit {
  isVisible: boolean = false;
  selectedDataIndex: number | null = null;
 
  DoctorDetailsForm: FormGroup;
 
  constructor(private fb: FormBuilder,
      public _commonService: CommonService,private communicationService:CommunicationService) {
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
   this.getAllDoctorItems()
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
 
      if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
        this._commonService.doctorDetailsFormData[this.selectedDataIndex] = doctorDetailsFormList;
      } else {
        this._commonService.doctorDetailsFormData.push(doctorDetailsFormList);
      }
 
      this.DoctorDetailsForm.reset();
      this.selectedDataIndex = null;
    } else {
      console.log("Error occurred")
    }
  };
 
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.DoctorDetailsForm.reset();
  };
 
  deleteData(index: number) {
    console.log("delete", index)
    this._commonService.doctorDetailsFormData.splice(index, 1);
  };
 
productDoctorList:any;
getAllDoctorItems(){
  this.communicationService.getDoctorDetails().subscribe((data:any)=>{
this._commonService.doctorDetailsFormData = data;
console.log(this.productDoctorList)
  })
};

showEditModel(index: number): void {
  const selectedData = this._commonService.doctorDetailsFormData[index];
  this.DoctorDetailsForm.patchValue(selectedData);
  this.selectedDataIndex = index;
  this.isVisible = true; 
};

handleCancel(): void {
  this.isVisible = false;
  this.DoctorDetailsForm.reset();
}

}
