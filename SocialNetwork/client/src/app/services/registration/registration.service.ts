import { Injectable } from '@angular/core';
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
  }
}
