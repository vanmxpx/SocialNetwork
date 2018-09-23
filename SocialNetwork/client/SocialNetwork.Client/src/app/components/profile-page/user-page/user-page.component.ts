import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

import { ProfileService } from '../../../services/model-services/profile.service';
import { Profile } from '../../../models/profile';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  public profile: Profile;
  private login: string;

  @Input() private color: ThemePalette;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private profileService: ProfileService
  ) {
    // override the route reuse strategy
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };

    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        // trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
        // if you need to scroll back to top, here is the right place
        window.scrollTo(0, 0);
      }
    });
  }


  private getProfile(): void {
    this.login = this.route.snapshot.paramMap.get('login');
    this.profileService.getProfile(this.login)
      .subscribe(profile => this.profile = profile);
  }

  ngOnInit() {
    this.getProfile();
  }
}
