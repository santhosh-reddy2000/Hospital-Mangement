
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-head-office',
  templateUrl: './head-office.component.html',
  styleUrls: ['./head-office.component.less']
})
export class HeadOfficeComponent {

  selectedValue = null;
  isVisible: boolean = false;
  showDeleteConfirmationModal = false;
  selectedDataIndex: number | null = null;
  deleteIndex: number | null = null;

  headOfficeForm: FormGroup;
  constructor(private fb: FormBuilder,
    public _commonService: CommonService, private communicationService: CommunicationService, private nzMessageService: NzMessageService) {
    this.headOfficeForm = this.fb.group({
      headOfficeName: ['', [Validators.required]],
      pinCode: [, [Validators.required, Validators.pattern('^\\d{6}$')]],
      // mobileNo: [, [Validators.required, Validators.pattern('^\\d{10}$')]],
      address: ['', [Validators.required]],
      website: ['', [Validators.required, Validators.pattern('^(http(s)?:\/\/)?([\\w-]+\\.)+[\\w-]+(\/[\\w- .\/?%&=]*)?$')]],
      email: ['', [Validators.email, Validators.required]],
    });
    console.log("window.location", window.location)
  };

  ngOnInit(): void {
    this.getAllHeadOffices();
  };

  submitForm(): void {
    if (this.headOfficeForm.valid) {
        const headOfficeFormList = {
            headOfficeName: this.headOfficeForm.value.headOfficeName,
            pincode: this.headOfficeForm.value.pinCode,
            address: this.headOfficeForm.value.address,
            website: this.headOfficeForm.value.website,
            email: this.headOfficeForm.value.email,
        };

        if (this.selectedDataIndex !== undefined && this.selectedDataIndex !== null) {
            const selectedData = this._commonService.headOfficeFormData[this.selectedDataIndex];
            const updatedData = { ...selectedData, ...headOfficeFormList };
            this.communicationService.UpdateHeadOffice(updatedData).subscribe((data: any) => {
                if (data) {
                    this.getAllHeadOffices();
                }
            });
        } else {
            this.addHeadOffice(headOfficeFormList);
        }
        this.headOfficeForm.reset();
        this.selectedDataIndex = null;
        this.isVisible = false;
    } else {
        console.log("Error occurred");
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

  showEditModel(index: number): void {
    const selectedData = this._commonService.headOfficeFormData[index];
    this.headOfficeForm.patchValue({
      headOfficeName: selectedData.headOfficeName,
      pinCode: selectedData.pinCode,
      address: selectedData.address,
      website: selectedData.website,
      email: selectedData.email
    });
    this.selectedDataIndex = index;
    this.isVisible = true;
  }
  

  handleCancel(): void {
    this.isVisible = false;
    this.headOfficeForm.reset();
  }


  //using api

  public getAllHeadOffices() {
    this.communicationService.getAllHeadOffices().subscribe((data: any) => {
      debugger
      this._commonService.headOfficeFormData = data.result;
    })
  }


  public addHeadOffice(headOfficeData: any) {
    this.headOfficeForm.reset();
    this.communicationService.addHeadOffice(headOfficeData).subscribe((data: any) => {
      this.getAllHeadOffices();
    });
  }

  public deleteHeadOffice(index: number) {
    const headOfficeIdToDelete = this._commonService.headOfficeFormData[index].id;
    this.communicationService.deleteHeadOffice(headOfficeIdToDelete).subscribe(() => {
      this.getAllHeadOffices();
    });
  }






}

