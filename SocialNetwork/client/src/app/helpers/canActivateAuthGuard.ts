import { CanActivate, Router } from '@angular/router';

import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';

import { Helpers } from './helpers';

import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()

export class AuthGuard implements CanActivate {

  constructor(private router: Router, private helper: Helpers) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    if (!this.helper.isAuthenticated()) {

      this.router.navigate(['/login']);

      return false;

    }

    return true;

  }

}