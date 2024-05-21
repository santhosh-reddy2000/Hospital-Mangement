import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-head-office-details',
  templateUrl: './head-office-details.component.html',
  styleUrl: './head-office-details.component.less'
})
export class HeadOfficeDetailsComponent implements OnInit{
  selectedValue = null;
  isVisible: boolean = false;
  selectedDataIndex: number | null = null;

  headOfficeForm: FormGroup;
  constructor(private fb: FormBuilder,
    public _commonService: CommonService, private communicationService: CommunicationService) {
    this.headOfficeForm = this.fb.group({
      headOfficeName: ['', [Validators.required]],
      pincode: [, [Validators.required, Validators.pattern('^\\d{6}$')]],
      mobileNo: [, [Validators.required, Validators.pattern('^\\d{10}$')]],
      address: ['', [Validators.required]],
      website: ['', [Validators.required, Validators.pattern('^(http(s)?:\/\/)?([\\w-]+\\.)+[\\w-]+(\/[\\w- .\/?%&=]*)?$')]],
      email: ['', [Validators.email, Validators.required]],
    });
    console.log("window.location", window.location)
  };

  ngOnInit(): void {
    this.getProductList()

  };
  submitForm(): void {
    if (this.headOfficeForm.valid) {
      const headOfficeFormList = {
        headOfficeName: this.headOfficeForm.value.headOfficeName,
        pincode: this.headOfficeForm.value.pincode,
        mobileNo: this.headOfficeForm.value.mobileNo,
        address: this.headOfficeForm.value.address,
        website: this.headOfficeForm.value.website,
        email: this.headOfficeForm.value.email,
      };

      if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
        this._commonService.headOfficeFormData[this.selectedDataIndex] = headOfficeFormList;
      } else {
        this._commonService.headOfficeFormData.push(headOfficeFormList);
      }
      
      this.headOfficeForm.reset();
      this.selectedDataIndex = null;
      this.isVisible = false; 
    } else {
      console.log("Error occurred")
    }
  }
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.headOfficeForm.reset();
  }

  deleteData(index: number) {
    console.log("delete", index)
    this._commonService.headOfficeFormData.splice(index, 1);
  }

  productListData: any;
  getProductList() {
    this.communicationService.getHeadOfficeData().subscribe((data: any) => {
      this._commonService.headOfficeFormData = data;
      console.log(this.productListData)
    })
  };

  
  showEditModel(index: number): void {
    const selectedData = this._commonService.headOfficeFormData[index];
    this.headOfficeForm.patchValue(selectedData);
    this.selectedDataIndex = index;
    this.isVisible = true; 
  }
  
  handleCancel(): void {
    this.isVisible = false;
    this.headOfficeForm.reset();
  }
}
