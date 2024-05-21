import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-branch-office',
  templateUrl: './branch-office.component.html',
  styleUrl: './branch-office.component.less'
})
export class BranchOfficeComponent implements OnInit {

  BranchDetailsForm: FormGroup;
 
   constructor(private fb: FormBuilder,
      public _commonService: CommonService,
      private communicationService: CommunicationService) {
      this.BranchDetailsForm = this.fb.group({
        HeadofficeList: ['', [Validators.required]],
        BranchName: ['', [Validators.required]],
        Branchcode: [, [Validators.required,Validators.pattern('^\\d{6}$')]],
        BranchServices: ['', [Validators.required]],
        Managername: ['', [Validators.required]],
        Address: ['', [Validators.required]],
        MobileNo: [, [Validators.required,Validators.pattern('^\\d{10}$')]],
        email: ['', [Validators.email,Validators.required]],
      });
    console.log("window.location", window.location)
  }
 
  ngOnInit(): void {
   this.getAllBranchOfficeDetails();
  }
  submitForm(): void {
    debugger;
    if (this.BranchDetailsForm.valid) {
 debugger;
      const branchDetailsFormList = {
              HeadofficeList: this.BranchDetailsForm.value.HeadofficeList,
              BranchName: this.BranchDetailsForm.value.BranchName,
              Branchcode: this.BranchDetailsForm.value.Branchcode,
              BranchServices: this.BranchDetailsForm.value.BranchServices,
              Managername: this.BranchDetailsForm.value.Managername,
              Address: this.BranchDetailsForm.value.Address,
              MobileNo: this.BranchDetailsForm.value.MobileNo,
              email: this.BranchDetailsForm.value.email,
            };
 
      
        // Add new data

        debugger;
        this._commonService.branchOfficeFormData.push(branchDetailsFormList);
      
 
      this.BranchDetailsForm.reset();
     
    } else {
      console.log("Error occurred")
    }
  }
 
  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.BranchDetailsForm.reset();
  }

  public getAllBranchOfficeDetails() {
    debugger;
    this.communicationService.getAllBranches().subscribe((data: any) => {
      this._commonService.branchOfficeFormData = data.result;
    })
  }

}
