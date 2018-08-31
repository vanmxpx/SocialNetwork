import { Component, OnInit, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { NgModule } from '@angular/core';
import { map } from 'rxjs/operators';
import { ThemePalette } from '@angular/material/core';
import { AuthenticationService } from '../../services';
import { Router } from '@angular/router';

import {
  MatButtonModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule
} from '@angular/material';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

@NgModule({
  imports: [
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
  ],
  exports: [
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
  ]
})

export class HeaderComponent {

  @Input()
  color: ThemePalette

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver,
    private authenticationService: AuthenticationService,
    private router: Router) {
  }

  Logout() {
    console.log("logout")
    this.authenticationService!.logout();
    this.router.navigate(['/login']);
  }

  MyProfile() {
    let login = JSON.parse(localStorage.getItem('login'));
    if (login) {
      this.router.navigate(['/profile/'  + login]);
    }
  }
}