import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';


@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private baseUrl = 'http://localhost:5000/api/';
  constructor(private http: HttpClient) { }

  postData(user: User) {
    const body = {email: user.email,
                  Login: user.login,
                  password: user.password,
                  name: user.firstname,
                  lastName: user.lastname};
    return this.http.post(this.baseUrl + 'credential/values', body); // FIX THIS
  }
}
