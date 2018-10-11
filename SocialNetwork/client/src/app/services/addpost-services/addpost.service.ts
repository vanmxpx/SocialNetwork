import { Injectable, EventEmitter } from '@angular/core';
import { Post } from '../../models/post';

@Injectable({
  providedIn: 'root'
})
export class AddpostService {
  public addNewPost = new EventEmitter<Post>();
  constructor() { }

  public addPost(post: Post) {
    this.addNewPost.emit(post);
  }
}
