import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationService } from '../../services/registration/registration.service';
import { AuthenticationService } from '../../services/security/authentication.service';
import { MatSnackBar } from '@angular/material';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationComponent implements OnInit {
  public user = new User();
  emailInput = new FormControl('', [Validators.required, Validators.email]);
  loginInput = new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(16)]);
  passwordInput = new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]);
  constructor(
    private registrationService: RegistrationService,
    private snackBar: MatSnackBar,
    private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }
  getRand() { return ''; }
  getEmailErrorMessage() {
    return this.emailInput.hasError('required') ? 'You must enter a value' :
      this.emailInput.hasError('email') ? 'Not a valid email' :
        '';
  }
  getPasswordErrorMessage() {
    return this.passwordInput.hasError('required') ? 'Yout must enter a value' :
      this.passwordInput.hasError('maxlength') ? 'value must be less then 16 char' :
        this.passwordInput.hasError('minlength') ? 'value must be longer then 8 char' :
          '';
  }
  getLoginErrorMessage() {
    return this.loginInput.hasError('required') ? 'Yout must enter a value' :
      this.loginInput.hasError('maxlength') ? 'value must be less then 16 char' :
        this.loginInput.hasError('minlength') ? 'value must be longer then 6 char' :
          '';
  }
  onSubmit() {
    if (!this.emailInput.invalid && !this.loginInput.invalid && !this.passwordInput.invalid) {
      this.registrationService.sendEmail(this.user).subscribe(
        (response: string) => {
          this.snackBar.open(response, undefined, { duration: 3000 });
        }
      );
    } else {
console.log('Error has occurred');
    }


  }



}
