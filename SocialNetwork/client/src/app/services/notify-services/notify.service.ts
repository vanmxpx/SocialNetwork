import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import { Post } from '../../models/post';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {

  private _hubConnection: HubConnection | undefined;
  private recievedPost: Post;
  public newPostReceived = new EventEmitter<Post>();

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  private createConnection() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/chatHub')
      .build();
  }
  private registerOnServerEvents(): void {
    this._hubConnection.on('ReceivePost', (recievedPost: Post) => {
      this.newPostReceived.emit(recievedPost);
    });
  }
  private startConnection() {
    this._hubConnection.start().catch(err => document.write(err));
  }
}
