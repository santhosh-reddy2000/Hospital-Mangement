import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrl: './patient-details.component.less'
})
export class PatientDetailsComponent implements OnInit {

  isVisible: boolean = false;
  selectedDataIndex: number | null = null;
 
  BranchDetailsForm: FormGroup;
  patientDetailsForm: FormGroup<{ doctorNamelist: FormControl<string>; 
  PatientName: FormControl<string>; 
  Age: FormControl<number>;
  RegistrationDate: FormControl<number>;
  Reasonforvist: FormControl<string>; 
  Address: FormControl<string>;
  MobileNumber: FormControl<number>; email: FormControl<string>; 
  languageKnow: FormControl<string>; 
  Gender: FormControl<string>; 
  BloodGroup: FormControl<string>; 
  maritalStatus: FormControl<string>; }>;
  constructor(private fb: FormBuilder,public _commonService: CommonService,private communicationServices:CommunicationService) {
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
    console.log("window.location", window.location)
  };
 
  ngOnInit(): void {
    this.patientDetailsList()
   
  };
  submitForm(): void {
    if (this.patientDetailsForm.valid) {
          const patientDetailsFormList = {
    
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
      if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
        this._commonService.patientDetailsFormData[this.selectedDataIndex] = patientDetailsFormList;
      } else {
        this._commonService.patientDetailsFormData.push(patientDetailsFormList);
      }
 
      this.patientDetailsForm.reset();
      this.selectedDataIndex = null;
    } else {
      console.log("Error occurred")
    }
  };
 
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.patientDetailsForm.reset();
  };

  deleteData(index: number) {
    console.log("delete", index)
    this._commonService.patientDetailsFormData.splice(index, 1);
  };

  patientList:any;
  patientDetailsList(){
    this.communicationServices.getPatientData().subscribe((data:any)=>{
      this._commonService.patientDetailsFormData = data;
      console.log(this.patientList)

    })
  };

  showEditModel(index: number): void {
    const selectedData = this._commonService.patientDetailsFormData[index];
    this.patientDetailsForm.patchValue(selectedData);
    this.selectedDataIndex = index;
    this.isVisible = true; 
  };
  
  handleCancel(): void {
    this.isVisible = false;
    this.patientDetailsForm.reset();
  }
}
