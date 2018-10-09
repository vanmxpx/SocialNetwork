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

  private Id: number;

  public newPostReceived = new EventEmitter<Post>();

  constructor() { }
  public RegisteredOnServer() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  private createConnection() {
    const token = JSON.parse(localStorage.getItem('token'));
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/chatHub', { accessTokenFactory: () => token })
      .configureLogging(signalR.LogLevel.Information)
      .build();
  }
  private registerOnServerEvents(): void {
    this._hubConnection.on('AddNewPostToNews', (newPost: Post) => {
      this.newPostReceived.emit(newPost);
    });
  }
  private startConnection() {
    this._hubConnection.start().catch(err => document.write(err));
  }
}
