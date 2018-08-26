import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService, AuthenticationService } from '../services';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) { }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        // сбросить статус входа в систему
        this.authenticationService.logout();

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
        this.authenticationService.login(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe(
                //перенаправление
                //FIXME: не отрабатывеает
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                //отображаем сообщение что данные не валидны
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}