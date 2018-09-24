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

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }
  public RegisteredOnServer(id: number) {
    this.Id = id;
    this._hubConnection.invoke('AddNewClient', id);
  }
  public logout() {
    this._hubConnection.invoke('DeleteClient', this.Id);
  }
  private createConnection() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/chatHub')
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
