import { AfterViewInit, Injectable, OnInit, Inject } from '@angular/core';
import { OktaAuthService } from 'src/app/services/oktaAuth.service';
import { OktaAuthStateService, OKTA_AUTH } from '@okta/okta-angular';
import { OktaAuth } from '@okta/okta-auth-js';
import { environment } from 'src/environments/environment';

interface Claim {
  claim: string;
  value: string;
}

@Injectable({
  providedIn: 'root'
})

export class CommonService implements OnInit, AfterViewInit {
  // isBranchOfficeVisible: boolean = false;
  public isInternalUser: boolean = undefined;
  public isOpenWellPageIsActive: boolean = false;
  public isSidebarCollapsed: boolean = true;

public headOfficeFormData:any[] = [];
public branchOfficeFormData:any[] = [];
public doctorDetailsFormData:any[]=[];
public patientDetailsFormData:any[]=[];


  //Auth //
  public env = environment;
  public userInfo: any = null;
  userName: string;
  userEmail: string = "";
  isAuthenticated: boolean;
  userClaims: any;
  idToken;
  claims: Array<Claim>;
  deleteHeadOffice: any;

  constructor(public oktaAuthService: OktaAuthService,
    public authService: OktaAuthStateService,
    @Inject(OKTA_AUTH) public oktaAuth: OktaAuth) {
    this.checkAuth()
  }

  ngOnInit() {
  }

  async checkAuth() {
    if (environment.userauthentication) {
      if (localStorage.getItem("UserInfo") !== undefined && localStorage.getItem("UserInfo") !== null) {
        this.userInfo = JSON.parse(localStorage.getItem("UserInfo"))
        if (this.userInfo.email.includes('@halliburton.com') || this.userInfo.email.includes('@Halliburton.com')) {
          this.isInternalUser = true;
        }
        else {
          this.isInternalUser = false;
        }
      }
      else {
        await this.authService.authState$.subscribe(
          {
            next:
              authenticated => {
                if (authenticated) {
                  this.isAuthenticated = true;
                  this.oktaAuth.getUser().then((data) => {
                    this.userInfo = data;
                    localStorage.setItem("UserInfo", JSON.stringify(this.userInfo))
                    if (this.userInfo.email.includes('@halliburton.com')) {
                      this.isInternalUser = true;
                    }
                    else {
                      this.isInternalUser = false;
                    }
                  }, (err) => {});
                }
              }
          }
        )
      }
    }
  }

  logout() {
    this.oktaAuthService.logout();
  }

  ngAfterViewInit(): void { }

}

