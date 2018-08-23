import { Injectable } from '@angular/core';
import { Post } from './models/post';
import { POSTS } from './mock-posts';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>("http://localhost:5000/api/posts?authorId=39");
  }
  constructor(private http: HttpClient) { }
}
