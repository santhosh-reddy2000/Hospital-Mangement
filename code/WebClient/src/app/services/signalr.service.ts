
import { Injectable } from "@angular/core";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { BehaviorSubject } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  private connectionEstablishedSubject = new BehaviorSubject<boolean>(false);
  connectionEstablished$ = this.connectionEstablishedSubject.asObservable();

  private isServerConnectedSubject = new BehaviorSubject<boolean>(false);
  isServerConnected$ = this.isServerConnectedSubject.asObservable();

  private connection: HubConnection;
  public signalRUrl: string = environment.signalRUrl;

  constructor() {
    this.createConnection();
    this.startConnection();

  }

  private createConnection() {
    this.isServerConnectedSubject.next(true);
    if (environment.userauthentication) {
      this.connection = new HubConnectionBuilder()
        .withUrl(this.signalRUrl) //, { accessTokenFactory: () => JSON.parse(localStorage.getItem("okta-token-storage")).accessToken.accessToken })
        .build();
    }
    else {
      this.connection = new HubConnectionBuilder()
        .withUrl(this.signalRUrl)
        .build();
    }

    this.connection.onclose(error => {
      console.log("now disconnected.. trying to connect again in 1 minutes");
      this.connectionEstablishedSubject.next(true);
      this.isServerConnectedSubject.next(false);
      localStorage.setItem('isServerConnected', 'false');
      setTimeout(() => this.startConnection(), 1000);
    });

  }

  private startConnection(): void {
    this.connection.serverTimeoutInMilliseconds = 100000;
    this.connection
      .start()
      .then(() => {
        setInterval(() => {
          this.connection.send('KeepAlive'); ``
          console.log("SignalR-KeepAlive");
        }, 60000);
        console.log('Hub connection started');
        try {
          if (environment.userauthentication) {
            this.connectionEstablishedSubject.next(true);
            this.isServerConnectedSubject.next(true);
            localStorage.setItem('isServerConnected', 'true');
            // this.registerOnServerEvents();
          }
          else {
            this.connectionEstablishedSubject.next(true);
            this.isServerConnectedSubject.next(true);
            this.connection.on("OnSimpleReceive", username => {
              localStorage.setItem('isServerConnected', 'true');
              // this.registerOnServerEvents();
            });
          }
        } catch (err) {
          console.log('Error while establishing connection, retrying...');
          this.isServerConnectedSubject.next(false);
          localStorage.setItem('isServerConnected', 'false');
          setTimeout(() => {
            this.startConnection();
          }, 1000);
          console.error(err);
        }
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        this.isServerConnectedSubject.next(false);
        localStorage.setItem('isServerConnected', 'false');
        setTimeout(() => {
          {
            if (!this.isConnected()) {
              this.InitConnection()
              this.startConnection();
            }
          }

        }, 1000);
      });
  }

  private isConnected(): boolean {
    return this.connection != null && this.connection.state == "Connected"

  }

  private InitConnection() {
    this.connection = new HubConnectionBuilder()
      .withUrl(this.signalRUrl)
      .build();
  }

}
