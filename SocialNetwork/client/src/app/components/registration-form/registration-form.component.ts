import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import {RegistrationService} from '../../services/registration/registration.service';
// import { InputDataValidatorService } from '../../validators/input-data-validator.service';



@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  public user = new User();
  // private loginValidator = this.validatorService.getLoginValidator();
  // private emailValidator = this.validatorService.getEmailValidator();
  // private passwordValidator = this.validatorService.getPasswordValidator();

  constructor(private registrationService: RegistrationService) { }

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
          this.registrationService.sendEmail(this.user).subscribe((response: string) => alert(response));
        }
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
