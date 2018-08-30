import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlSegment } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let login = JSON.parse(localStorage.getItem('login'));
        let token = JSON.parse(localStorage.getItem('token'));
        console.log(login);
        console.log(token);
        console.log(state.url);

        if (token) {
            // пользователь вошёл в систему 
            if (state.url.includes("login") && login) {
                this.router.navigate(['/profile/' + login]);
            }
            return true;
        }

        // пользователь не залогиненый, переадркссовываем его на строницу /login
        console.log("reload to login AuthGuard")
        this.router.navigate(['/login']);
        return false;
    }
}