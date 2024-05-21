

import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  public Url = 'http://localhost:53045/api/v1/';
  constructor(private _http: HttpClient) {}
  
  public getHeadOfficeData(){
    return this._http.get('assets/headoffice.json')
};

public getBrachOfficeData(){
  return this._http.get('assets/branch.json')
};

public getDoctorDetails(){
  return this._http.get('assets/doctor.json')
}

public getPatientData(){
  return this._http.get('assets/patient.json')
}
  public getVersion(){
    return this._http.get(`${environment.baseUrl}/serverversion`)
  }


  //HeadOffice
public getAllHeadOffices() {
  return this._http.get(`${this.Url}HeadOffice/GetAllHeadOffices`)
}

public addHeadOffice(headOfficeData: any) {
  return this._http.post(`${this.Url}HeadOffice/AddHeadOffice`, headOfficeData);
}

public deleteHeadOffice(headOfficeId: number) {
  return this._http.delete(`${this.Url}HeadOffice/DeleteHeadOffice?headOfficeId=${headOfficeId}`);
}
public UpdateHeadOffice(headOfficeData: any) {
  return this._http.post(`${this.Url}HeadOffice/UpdateHeadoffice`,headOfficeData);
}



// Branch
//http://localhost:53045/api/v1/Branch/GetAllBranches
public getAllBranches(){
  return this._http.get(`${this.Url}Branch/GetAllBranches`)
}
public addBranch(branch: any) {
  return this._http.post(`${this.Url}Branch/AddBranch`, branch);
}

public deleteAllBranch(branchId: number) {
  return this._http.delete(`${this.Url}Branch/DeleteBranch?headOfficeId=${branchId}`);
}
public updateAllBranch(branch: any) {
  return this._http.post(`${this.Url}Branch/UpdateBranch`,branch);
}


}