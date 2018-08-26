import { Injectable } from '@angular/core';
import { Post } from '../models/post';
import { Profile } from '../models/profile';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  getPosts(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>("http://localhost:5000/api/posts?authorId=" + profileId.toString());
  }
  getNews(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>("http://localhost:5000/api/posts/news/?id=" + profileId.toString());
  }

  constructor(private http: HttpClient) { }
}
