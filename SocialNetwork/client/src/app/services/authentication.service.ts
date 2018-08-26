import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }
 
    login(username: string, password: string) {

        //FIXME: fix logic always false
        return this.http.post<any>(`${environment.apiUrl}/api/authorizations/`, { email: username, password: password })
            .pipe(map(user => {
                // login успешно, если в ответе есть токен jwt
                if (user && user.token) {
                    //сохраняем токен jwt в локальном хранилище
                    localStorage.setItem('user', JSON.stringify(user.token));
                } 
                return user;
            }));
    }
 
    logout() {
        // удаляем токен для выхода из системы
        localStorage.removeItem('user');
    }
}