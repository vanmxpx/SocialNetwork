import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlSegment } from '@angular/router';
 
@Injectable()
export class AuthGuard implements CanActivate {
 
    constructor(private router: Router) { }
 
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('token')) {
            // пользователь вошёл в систему            
            console.log(localStorage.getItem('token'));
            
            if(this.router.url.indexOf('/login')>-1){

                this.router.navigate(['/profile/' + +JSON.parse(localStorage.getItem("login"))]);
            }
            return true;
        }        

        // пользователь не залогиненый, переадркссовываем его на строницу /login
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}