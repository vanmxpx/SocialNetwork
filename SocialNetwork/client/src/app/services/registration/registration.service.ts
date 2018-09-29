import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';

import { User } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private url = 'http://localhost:5000/api/registration';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  constructor(private http: HttpClient) { }

  sendEmail(user: User) {
    return this.http.post<string>(this.url, user, this.httpOptions);
    // .pipe(
    //   catchError((df: string) => {
    //     console.log(df);
    //    return df;
    //   }
    //   ));
  }
}
