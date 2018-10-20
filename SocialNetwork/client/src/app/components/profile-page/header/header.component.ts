import { Component, OnInit } from '@angular/core';
import { Profile } from '../../../models/profile';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  private returnURL: string;
  public userProfile;
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this.returnURL = this.activatedRoute.snapshot.queryParams['returnUrl'] || '/';
    this.userProfile = JSON.parse(localStorage.getItem('profile'));
  }

  PersonButtonClick() {
    this.router.navigate([this.returnURL + 'profile/' + this.userProfile.login]);
  }
  AppExtiButtonClick() {
    localStorage.clear();
    this.router.navigate([this.returnURL + 'login']);
  }

  GetPictureURL() {
    if (this.userProfile !== null) {
      return this.userProfile.photoUrl;
    }

  }

}
