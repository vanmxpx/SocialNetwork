import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
<<<<<<< HEAD
import { InputDataValidatorService } from '../../validators/input-data-validator.service';
import { RegistrationService } from '../../services/registration/registration.service';

=======
import { InputDataValidatorService } from '../../services/validators/input-data-validator.service';
import { RegistrationService } from '../../services/registration/registration.service';
>>>>>>> 1940cbdac2eeb2ac39c389d2c63d688bd507360b



@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  private hide = true;
  private showEmailNotification = false;
  private user = new User();

  private loginValidator = this.validatorService.getLoginValidator();
  private emailValidator = this.validatorService.getEmailValidator();
  private passwordValidator = this.validatorService.getPasswordValidator();

  constructor(private validatorService: InputDataValidatorService,
    private registrationService: RegistrationService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.user.login = this.loginValidator.value;
    this.user.email = this.emailValidator.value;
    this.user.password = this.passwordValidator.value;
    if (this.loginValidator.status === 'VALID'
      && this.emailValidator.status === 'VALID'
      && this.passwordValidator.status === 'VALID') {
      this.showEmailNotification = true;
      // alert('Request imitation: ' + JSON.stringify(this.user));
      // tslint:disable-next-line:max-line-length
<<<<<<< HEAD
      const t = this.registrationService.Register(this.user);
=======
      const t = this.registrationService.postEmail(this.user.email);
>>>>>>> 1940cbdac2eeb2ac39c389d2c63d688bd507360b
      // this.registrationService.postData(this.user)
      //           .subscribe(
      //               (data: User) => {this.user = data; },
      //               error => console.log(error)
      //           );
      // alert('reques');
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
