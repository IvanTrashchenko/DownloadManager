import { Inject, Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  public messages: string[] = [];

  constructor(
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(baseUrl + 'logHub')
      .build();

    this.hubConnection.on('ReceiveLog', (message: string) => {
      this.messages.push(message);
    });

    this.hubConnection.start().catch(err => console.error(err));
  }
}
