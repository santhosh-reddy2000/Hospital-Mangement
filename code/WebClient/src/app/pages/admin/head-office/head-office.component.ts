import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-head-office',
  templateUrl: './head-office.component.html',
  styleUrl: './head-office.component.less'
})
export class HeadOfficeComponent {
  headOfficeForm: FormGroup;
 
  constructor(private fb: FormBuilder,
    public _commonService: CommonService) {
    this.headOfficeForm = this.fb.group({
      HeadOfficeName: ['', [Validators.required]],
      pincode: [, [Validators.required, Validators.pattern('^\\d{6}$')]],
      MobileNo: [, [Validators.required, Validators.pattern('^\\d{10}$')]],
      Address: ['', [Validators.required]],
      Website: ['', [Validators.required]],
      email: ['', [Validators.email, Validators.required]],
    });
    console.log("window.location", window.location)
  }
 
  ngOnInit(): void {
   
  }
  submitForm(): void {
    if (this.headOfficeForm.valid) {
 
      const headOfficeFormList = {
        HeadOfficeName: this.headOfficeForm.value.HeadOfficeName,
        pincode: this.headOfficeForm.value.pincode,
        MobileNo: this.headOfficeForm.value.MobileNo,
        Address: this.headOfficeForm.value.Address,
        Website: this.headOfficeForm.value.Website,
        email: this.headOfficeForm.value.email,
      };
 
     // Add new data
        this._commonService.headOfficeFormData.push(headOfficeFormList);
      this.headOfficeForm.reset();
    
    } else {
      console.log("Error occurred")
    }
  }
 
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.headOfficeForm.reset();
  }

}
