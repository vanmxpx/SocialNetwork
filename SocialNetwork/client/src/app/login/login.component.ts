import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService, AuthenticationService } from '../services';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    login: string;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', Validators.required],
            password: ['', Validators.required]
        });
        
        //получить URL-адрес возврата из параметров маршрута или по умолчанию '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // getter для loginForm
    get f() { return this.loginForm.controls; }

    //callback функция события клика по кнопке войти в форме на странице /login
    onSubmit() {

        this.submitted = true;

        // данные формы не валидны
        if (this.loginForm.invalid) {
            return;
        }

        this.loading = true;

        this.authenticationService.login(this.f.email.value, this.f.password.value)
            .subscribe(
                //перенаправление на страницу профиля по login в local Storage
                data => {
                    this.router.navigate([this.returnUrl+"profile/" + JSON.parse(localStorage.getItem('login'))]);
                },

                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}