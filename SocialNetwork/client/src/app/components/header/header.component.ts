import { Component, OnInit, Input } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { Router } from '@angular/router';
import { BreakpointObserver } from '@angular/cdk/layout';

import { AuthenticationService } from '../../services/security/authentication.service';
import { NotifyService } from '../../services/notify-services/notify.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})

export class HeaderComponent {

    @Input() private color: ThemePalette;

    // isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    //   .pipe(
    //     map(result => result.matches)
    //   );

    // constructor(private breakpointObserver: BreakpointObserver) { }
    constructor(private breakpointObserver: BreakpointObserver,
        private authenticationService: AuthenticationService,
        private router: Router,
        private notifyService: NotifyService) {
    }
    Logout() {
        this.notifyService.logout();
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }

    MyProfile() {
        const login = JSON.parse(localStorage.getItem('login'));
        this.router.navigateByUrl('/profile/' + login);
    }
}
