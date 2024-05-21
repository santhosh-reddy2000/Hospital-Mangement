import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-branch-office-details',
  templateUrl: './branch-office-details.component.html',
  styleUrl: './branch-office-details.component.less'
})
export class BranchOfficeDetailsComponent implements OnInit {
  isVisible: boolean = false;
  selectedDataIndex: number | null = null;
  BranchDetailsForm: FormGroup;

  constructor(private fb: FormBuilder,
    public _commonService: CommonService, private communicationService: CommunicationService) {
    this.BranchDetailsForm = this.fb.group({
      HeadofficeList: ['', [Validators.required]],
      BranchName: ['', [Validators.required]],
      Branchcode: [, [Validators.required, Validators.pattern('^\\d{6}$')]],
      BranchServices: ['', [Validators.required]],
      Managername: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      MobileNo: [, [Validators.required, Validators.pattern('^\\d{10}$')]],
      Email: ['', [Validators.email, Validators.required]],
    });
    console.log("window.location", window.location)
  };
  ngOnInit(): void {
    this.getAllDataList()
    console.log(this._commonService.headOfficeFormData)
  };
  submitForm(): void {
    if (this.BranchDetailsForm.valid) {

      const branchDetailsFormList = {
        HeadofficeList: this.BranchDetailsForm.value.HeadofficeList,
        BranchName: this.BranchDetailsForm.value.BranchName,
        Branchcode: this.BranchDetailsForm.value.Branchcode,
        BranchServices: this.BranchDetailsForm.value.BranchServices,
        Managername: this.BranchDetailsForm.value.Managername,
        Address: this.BranchDetailsForm.value.Address,
        MobileNo: this.BranchDetailsForm.value.MobileNo,
        Email: this.BranchDetailsForm.value.Email,
      };

      if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
        this._commonService.branchOfficeFormData[this.selectedDataIndex] = branchDetailsFormList;
      } else {
        this._commonService.branchOfficeFormData.push(branchDetailsFormList);
      }

      this.BranchDetailsForm.reset();
      this.selectedDataIndex = null;
      this.isVisible = false; 
    } else {
      console.log("Error occurred")
    }
  };

  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.BranchDetailsForm.reset();
  };

  deleteData(index: number) {
    console.log("delete", index)
    this._commonService.branchOfficeFormData.splice(index, 1);
  };
  productData: any;
  getAllDataList() {
    this.communicationService.getBrachOfficeData().subscribe((data: any) => {
      this._commonService.branchOfficeFormData = data;
      console.log(this.productData)
    })
  };

  showEditModel(index: number): void {
    const selectedData = this._commonService.branchOfficeFormData[index];
    this.BranchDetailsForm.patchValue(selectedData);
    this.selectedDataIndex = index;
    this.isVisible = true; 
  };
  
  handleCancel(): void {
    this.isVisible = false;
    this.BranchDetailsForm.reset();
  }

}
