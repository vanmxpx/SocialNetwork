import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../models/user';
import { Observable } from 'rxjs';



const baseUrl = 'http://localhost:5000/api/credentials';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/x-www-form-urlencoded',
  })
};

const headers: HttpHeaders = new HttpHeaders().set('content-type', 'application/json');

@Injectable()
export class RegistrationService {

  constructor(private http: HttpClient) { }
  Register(user: User) {
    const body = {
      email: 'dfd'
    };
    const request = '/' + user.email + '/' + user.login + '/' + user.password + '/' + user.firstname + '/' + user.lastname;
    return this.http.post<any>(baseUrl + request, body, httpOptions);
  }
}
