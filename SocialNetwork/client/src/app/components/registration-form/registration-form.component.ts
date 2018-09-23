import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
// import { InputDataValidatorService } from '../../validators/input-data-validator.service';



@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  public user = new User();
  private url = 'http://localhost:5000/api/registration';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };
  // private loginValidator = this.validatorService.getLoginValidator();
  // private emailValidator = this.validatorService.getEmailValidator();
  // private passwordValidator = this.validatorService.getPasswordValidator();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  onSubmit() {
    if (this.user.email === undefined) {
      // обработка пустого email
    } else
      if (this.user.login === undefined) {
        // обработка пустого login
      } else
        if (this.user.password === undefined) {
          // обработка пустого password
        } else {
          this.sendEmail(this.user).subscribe((response: string) => alert(response));
        }
  }

  sendEmail(user: User) {
    return this.http.post<string>(this.url, user, this.httpOptions);
  }

  // getEmailErrorMessage() {
  //   return this.validatorService.getEmailErrorMessage();
  // }

  // getLoginErrorMessage() {
  //   return this.validatorService.getLoginErrorMessage();
  // }

  // getPasswordErrorMessage() {
  //   return this.validatorService.getPasswordErrorMessage();
  // }

}
