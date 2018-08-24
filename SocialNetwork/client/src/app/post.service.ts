import { Injectable } from '@angular/core';
import { Post } from './models/post';
import { Profile } from './models/profile';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  getPosts(profileId:number): Observable<Post[]> {
    return this.http.get<Post[]>("http://localhost:5000/api/posts?authorId="+profileId.toString());
  }
  getProfile(): Observable<Profile> {
    return this.http.get<Profile>("http://localhost:5000/api/profiles/24");
  }
  constructor(private http: HttpClient) { }
}
