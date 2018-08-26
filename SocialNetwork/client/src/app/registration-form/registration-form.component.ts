import { Component, OnInit } from '@angular/core';

import { User } from '../models/user';
import {InputDataValidatorService} from '../input-data-validator.service';

@Component({
  selector: 'registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationComponent implements OnInit {
  private hide = true;
  private showEmailNotification = false;
  private user = new User();

  private loginValidator = this.validatorService.getLoginValidator();
  private emailValidator = this.validatorService.getEmailValidator();
  private passwordValidator = this.validatorService.getPasswordValidator();

  constructor(private validatorService: InputDataValidatorService) { }
  
  ngOnInit() {
  }
  
  onSubmit() {
    this.user.login = this.loginValidator.value;
    this.user.email = this.emailValidator.value;
    this.user.password = this.passwordValidator.value;
      if(this.loginValidator.status === 'VALID'
         && this.emailValidator.status === 'VALID'
         && this.passwordValidator.status === 'VALID'){
        this.showEmailNotification = true;
        alert("Request imitation: " + JSON.stringify(this.user));
      }
  }

  getEmailErrorMessage() {
    return this.validatorService.getEmailErrorMessage();
  }

  getLoginErrorMessage() {
    return this.validatorService.getLoginErrorMessage();
  }

  getPasswordErrorMessage() {
    return this.validatorService.getPasswordErrorMessage();
  }

}
