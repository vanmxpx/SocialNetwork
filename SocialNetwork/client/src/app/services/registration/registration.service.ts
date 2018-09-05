import { Injectable } from '@angular/core';
<<<<<<< HEAD
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/user';
import { Observable } from 'rxjs';



const baseUrl = 'http://localhost:5000//api/credentials';


@Injectable()
export class RegistrationService {

  constructor(private http: HttpClient) { }
  Register(user: User) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'email': user.email,
        'login': user.login,
        'password': user.password
      })
    };
    this.http.post(baseUrl, httpOptions);
=======
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
>>>>>>> 1940cbdac2eeb2ac39c389d2c63d688bd507360b
  }
}
