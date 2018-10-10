import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { timeout, catchError } from 'rxjs/operators';

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
  getProfiles(login: string, from: number, to: number): Observable<Profile[]> {
    // tslint:disable-next-line:max-line-length
    return this.http.get<Profile[]>('http://localhost:5000/api/profiles/' + login + '/' + from.toString() + '/' + to.toString()).pipe(
      timeout(3000),
      catchError(e => {
        // do something on a timeout
        return of(null);
      })
    );
  }
  constructor(private http: HttpClient) { }


}
