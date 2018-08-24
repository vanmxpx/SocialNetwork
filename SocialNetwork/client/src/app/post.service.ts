import { Injectable } from '@angular/core';
import { Post } from './models/post';
import { Profile } from './models/profile';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  getPosts(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>("http://localhost:5000/api/posts?authorId=" + profileId.toString());
  }
  getProfile(login: string): Observable<Profile> {
    return this.http.get<Profile>("http://localhost:5000/api/profiles/login/?login=" + login);
  }
  getSubscribers(profileId: number): Observable<Profile[]> {
    return this.http.get<Profile[]>("http://localhost:5000/api/followings/subscribers/?id=" + profileId.toString());
  }
  getBloggers(profileId: number): Observable<Profile[]> {
    return this.http.get<Profile[]>("http://localhost:5000/api/followings/bloggers/?id=" + profileId.toString());
  }
  constructor(private http: HttpClient) { }
}
