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
  public userProfile = JSON.parse(localStorage.getItem('profile'));
  constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.returnURL = this.activatedRoute.snapshot.queryParams['returnUrl'] || '/';
  }

  PersonButtonClick() {
    this.router.navigate([this.returnURL + 'profile/' + JSON.parse(localStorage.getItem('login'))]);
  }

}
