import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { Profile } from '../../../models/profile';
import { FollowingsService } from '../../../services/model-services/followings.service';
import { Following } from '../../../models/following';


@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})

export class UserInfoComponent implements OnInit {
  @Input() public profile: Profile;
  public isSubscriber: boolean;
  public isUser: boolean;
  public userProfile = JSON.parse(localStorage.getItem('profile'));

  constructor(
    private followingService: FollowingsService,
    private router: Router) { }

  private getRelationship(): void {
    this.followingService.checkOnRelationship(this.profile.id, this.userProfile.id)
      .subscribe(isSubsciber => this.isSubscriber = isSubsciber);
  }
  get labelName(): string {
    return this.isSubscriber ? 'Unsubscribe' : 'Subscribe';
  }
  private checkOnOwner(): boolean {
    if (this.profile.id === this.userProfile.id) {
      return true;
    }
    return false;
  }
  public toggleRelationship() {
    if (this.isSubscriber) {
      this.deleteRelationship();
    } else {
      this.addRelationship();
    }
  }
  private addRelationship() {
    this.followingService.addRelationship(
      {
        bloggerRef: this.profile.id,
        subscriberRef: this.userProfile.id
      }
    )
      .subscribe(
        (data: Following) => {
          this.router.navigateByUrl('/profile/' + this.profile.login);
        },
        error => console.log(error)
      );
  }
  private deleteRelationship() {
    this.followingService.deleteRelationship(this.profile.id, this.userProfile.id)
      .subscribe(
        (data: Following) => {
          this.router.navigateByUrl('/profile/' + this.profile.login);
        },
        error => console.log(error)
      );
  }

  ngOnInit() {
    this.getRelationship();
    this.isUser = this.checkOnOwner();
  }
}
