import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { Profile } from '../../../models/profile';
import { ProfileService } from '../../../services/model-services/profile.service';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit, AfterViewInit {
  public isAuthorizedUserProfile: boolean;
  @Input() public profile: Profile;
  public subscribers: Profile[] = [];
  public bloggers: Profile[] = [];

  constructor(
    private profileService: ProfileService) { }

  private getSubscribers(): void {
    this.profileService.getSubscribers(this.profile.id)
      .subscribe(profiles => this.subscribers = profiles);
  }
  private getBloggers(): void {
    this.profileService.getBloggers(this.profile.id)
      .subscribe(profiles => this.bloggers = profiles);
  }
  private checkOnMine(): void {
    this.isAuthorizedUserProfile = (localStorage.getItem('login') === JSON.stringify(this.profile.login)) ? true : false;
  }


  ngOnInit() {
    this.checkOnMine();
  }

  ngAfterViewInit() {
    this.getSubscribers();
    this.getBloggers();
  }
}
