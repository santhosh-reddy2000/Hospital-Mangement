import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from 'src/app/services/common.service';
import { CommunicationService } from 'src/app/services/communication.service';
import { SignalRService } from 'src/app/services/signalr.service';
import { environment } from 'src/environments/environment';
import { SidebarService } from './sidebar.service';
import { NzResizeEvent } from 'ng-zorro-antd/resizable';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.less'
})
export class SidebarComponent {

  public applicationVersion: string;
  public serverConnectionLight: boolean = false;

  constructor(
    public _communicationService: CommunicationService,
    public signalRService : SignalRService,
    public sidebarservice: SidebarService,) {
  
    this.subscribeToConnectionStatus();
    if (localStorage.getItem('isServerConnected') == 'true') {
      this.serverConnectionLight = true;
    }
    if (localStorage.getItem('isServerConnected') == 'false') {
      this.serverConnectionLight = false;
    }
  }

  ngOnInit(): void {}

  public subscribeToConnectionStatus(): void {
    this.signalRService.isServerConnected$.subscribe((data: any) => {
      if (data === true) {
        this.serverConnectionLight = true;
      }
      if (data === false) {
        this.serverConnectionLight = false;
      }
    });
  }

  getVersion(){
    this._communicationService.getVersion().subscribe((data: any) =>{
      this.applicationVersion = data.Data;
    })
  }

}
