import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class SidebarService {

  public menuitems: any = [
    {
      name: "head-office",
      id: 101,
      index: 0,
      nzicon: "bank",
      DisplayName: "Head office",
      isVisible: true,
      expandStatus: false,
    },
   
    {
      name: "branch-office",
      id: 102,
      index: 0,
      nzicon: "home",
      DisplayName: "Branch Office",
      isVisible: true,
      expandStatus: false,
    },

    {
      name: "Doctor-Details",
      id: 103,
      index: 0,
      nzicon: "user-add",
      DisplayName: "Doctor Details",
      isVisible: true,
      expandStatus: false,
    },
    
    {
      name: "Patient-Details",
      id: 104,
      index: 0,
      nzicon: "user",
      DisplayName: "Patient Details",
      isVisible: true,
      expandStatus: false,
    },



    {
      name: "admin",
      id: 105,
      index: 0,
      nzicon: "user",
      DisplayName: "Admin",
      isVisible: true,
      expandStatus: false,
    },
    
    {
      name: "admin-Details",
      id: 106,
      index: 0,
      nzicon: "user",
      DisplayName: "Admin Details",
      isVisible: true,
      expandStatus: false,
    },
    




  ]

  public openHandler(index: number, openStatus: boolean = false): void {
    if (openStatus) {
      this.menuitems[index].expandStatus = true
    }

    this.menuitems.forEach(menu => {
      if (menu.index != index) {
        this.menuitems[menu.index].expandStatus = false;
      }
    });
  }

}
