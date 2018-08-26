import { Injectable } from '@angular/core';

import {FormControl, Validators} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class InputDataValidatorService {
  private emailValidator = new FormControl('', [Validators.required, Validators.email]);
  private loginValidator = new FormControl('', [Validators.required, Validators.minLength(6)]);
  private passwordValidator = new FormControl('', [Validators.required, Validators.minLength(8)]);

  constructor() { }

  getLoginValidator(){
    return this.loginValidator;
  }

  getEmailValidator(){
    return this.emailValidator;
  }

  getPasswordValidator(){
    return this.passwordValidator;
  }

  getEmailErrorMessage() {
    return this.emailValidator.hasError('required') ? 'You must enter a value' :
        this.emailValidator.hasError('email') ? 'Not a valid email' :
            '';
  }

  getLoginErrorMessage() {
    return this.loginValidator.hasError('required') ? 'You must enter a login value' :
        this.loginValidator.hasError('minlength') ? 'You have to enter more than 6 symbols' :
            '';
  }

  getPasswordErrorMessage() {
    return this.passwordValidator.hasError('required') ? 'You must enter a password value' :
        this.passwordValidator.hasError('minlength') ? 'You have to enter more than 8 symbols' :
            '';
  }
}
