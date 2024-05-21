
import { Component } from '@angular/core';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { Branch } from 'src/app/models/branch';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';
@Component({
  selector: 'app-branch-details',
  templateUrl: './branch-details.component.html',
  styleUrl: './branch-details.component.less'
})
export class BranchDetailsComponent {

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
   
  };
  submitForm(): void {
    debugger
    if (this.BranchDetailsForm.valid) {

      let branch = new Branch();
      branch.headOfficeId = this.BranchDetailsForm.value.HeadofficeList,
      branch.branchName = this.BranchDetailsForm.value.BranchName,
      branch.branchCode = this.BranchDetailsForm.value.Branchcode,
      branch.branchServices = this.BranchDetailsForm.value.BranchServices,
      branch.managerName = this.BranchDetailsForm.value.Managername,
      branch.address = this.BranchDetailsForm.value.Address,
      branch.mobileNo = this.BranchDetailsForm.value.MobileNo,
      branch.email = this.BranchDetailsForm.value.Email

      console.log('branch',branch);

      this.communicationService.addBranch(branch).subscribe((data:any) =>{
        debugger
        if(data){

        }
      })

      // if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
      //   this._commonService.branchOfficeFormData[this.selectedDataIndex] = branchDetailsFormList;
      // } else {
      //   this._commonService.branchOfficeFormData.push(branchDetailsFormList);
      // }

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

//using apis's
  getAllBranchDetailsList: any;
  public getAllBranchOffices() {
    this.communicationService.getAllBranches().subscribe((data: any) => {
      console.log("data",data)
      this.getAllBranchDetailsList = data;
    })
  }

}




