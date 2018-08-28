import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';


@Injectable()
export class AuthenticationService {

    constructor(private http: HttpClient) { }

    login(email: string, password: string) {

        return this.http.post<any>(`${environment.apiUrl}/api/authorizations/`, { email: email, password: password })
            .pipe(map(user => {
                // login успешно, если в ответе есть токен jwt
                if (user && user.token) {
                    //сохраняем токен jwt в локальном хранилище
                    localStorage.setItem('token', JSON.stringify(user.token));
                    localStorage.setItem('login', JSON.stringify(user.login))
                }
                return user;
            }));
    }

    logout() {
        // удаляем токен для выхода из системы
        localStorage.removeItem('token');
        localStorage.removeItem('login');
    }
}