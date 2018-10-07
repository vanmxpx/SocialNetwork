import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';

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

  public uploadAvatar(avatar: File): Observable<any> {
    const formData = new FormData();

        formData.append(avatar.name, avatar);

        const uploadReq = new HttpRequest('POST', 'http://localhost:5000/api/profiles', formData, {
            reportProgress: true,
        });
    return this.http.request(uploadReq);
  }


  constructor(private http: HttpClient) { }


}
