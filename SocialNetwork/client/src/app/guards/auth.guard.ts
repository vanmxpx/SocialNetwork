import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
 
@Injectable()
export class AuthGuard implements CanActivate {
 
    constructor(private router: Router) { }
 
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('user')) {
            // пользователь вошёл в систему
            return true;
        }
 
        // пользователь не залогиненый, переадркссовываем его на строницу /login
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}