import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';


@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private baseUrl = 'http://localhost:5000/api';
  constructor(private http: HttpClient) { }

  postData(email: string, login: string, password: string, name: string | null, lastName: string | null) {
    const body = {
      email: email,
      Login: login,
      password: password,
      name: name,
      lastName: lastName
    };
    // tslint:disable-next-line:max-line-length
    const request = 'http://localhost:5000//api/credential/Noderoid64@gmail.com/Noderoid/1488184/Misha/ddd'; // this.baseUrl + 'credential/' + email + '/' + login + '/' + password + '/' + name + '/' + lastName ;
    return this.http.get(request); // FIX THIS
  }
  postEmail(mail: string) {
    const body = {
      email: mail
    };
    return this.http.post(this.baseUrl + '/credential', body);
  }
}
