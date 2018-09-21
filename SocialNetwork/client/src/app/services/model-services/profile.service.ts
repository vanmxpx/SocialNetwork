import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Profile } from '../../models/profile';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class ProfileService {
  getProfile(login: string): Observable<Profile> {
    return this.http.get<Profile>('http://localhost:5000/api/profiles/login/?login=' + login);
  }
  getSubscribers(profileId: number): Observable<Profile[]> {
    return this.http.get<Profile[]>('http://localhost:5000/api/followings/subscribers/?id=' + profileId.toString());
  }
  getBloggers(profileId: number): Observable<Profile[]> {
    return this.http.get<Profile[]>('http://localhost:5000/api/followings/bloggers/?id=' + profileId.toString());
  }
  constructor(private http: HttpClient) { }


}
