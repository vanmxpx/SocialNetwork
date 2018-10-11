import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthenticationService } from '../../services/security/authentication.service';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  loginForm = new  FormGroup({
    emailInput: new FormControl('', [Validators.email, Validators.required]),
    passwordInput: new FormControl('', [Validators.minLength(6), Validators.maxLength(16), Validators.required])
  });
  hide = false;
  loading = false;
  submitted = false;
  returnUrl: string;
  login: string;

  constructor(
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) {
    if (route.snapshot.params['email'] !== undefined && route.snapshot.params['password'] !== undefined) {
      this.authenticationService.login(route.snapshot.params['email'], route.snapshot.params['password'])
      .subscribe(
        // перенаправление на страницу профиля по login в local Storage
        data => {
          this.router.navigate([this.returnUrl + 'profile/' + JSON.parse(localStorage.getItem('login'))]);
        },
        error => {
          this.loading = false;
        });
    }
  }

  ngOnInit() {
    // получить URL-адрес возврата из параметров маршрута или по умолчанию '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // callback функция события клика по кнопке войти в форме на странице /login
  onSubmit() {
    this.submitted = true;

    // данные формы не валидны
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;

    this.authenticationService.login(this.loginForm.controls['emailInput'].value, this.loginForm.controls['passwordInput'].value)
      .subscribe(
        // перенаправление на страницу профиля по login в local Storage
        data => {
          this.router.navigate([this.returnUrl + 'profile/' + JSON.parse(localStorage.getItem('login'))]);
        },
        error => {
          this.snackBar.open(error, undefined, { duration: 3000 });
        });
  }
  getEmailErrorMessage() {
    return this.loginForm.controls['emailInput'].hasError('required') ? 'You must enter a value' :
      this.loginForm.controls['emailInput'].hasError('email') ? 'Not a valid email' :
        '';
  }
  getPasswordErrorMessage() {
    return this.loginForm.controls['passwordInput'].hasError('required') ? 'Yout must enter a value' :
      this.loginForm.controls['passwordInput'].hasError('maxlength') ? 'value must be less then 16 char' :
        this.loginForm.controls['passwordInput'].hasError('minlength') ? 'value must be longer then 8 char' :
          '';
  }
}
