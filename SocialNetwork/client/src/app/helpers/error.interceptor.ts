import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router} from '@angular/router';
import { AuthenticationService } from '../services';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private router: Router) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        // localStorage.setItem('token', JSON.stringify("token"));
        // localStorage.setItem('login', JSON.stringify("login"))
   
        // let token=JSON.parse(localStorage.getItem('token'));
        // let login=JSON.parse(localStorage.getItem('login'));
       
        // if(request.url.includes("/login") && token && login){
        //     this.router.navigate(['profile/' + login]);
        // }
        
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                this.authenticationService.logout();
                this.router.navigate(['/login']);
            }
            
            const error = err.error.message || err.statusText;
            return throwError(error);
        }))
    }
}