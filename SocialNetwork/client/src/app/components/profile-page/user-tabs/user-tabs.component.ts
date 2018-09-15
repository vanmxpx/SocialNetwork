import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../../../models/profile';
import { Post } from '../../../models/post';
import { ProfileService } from '../../../services/model-services/profile.service';
import { PostService } from '../../../services/model-services/post.service';
import { MatTabChangeEvent } from '@angular/material';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit {
  @Input() public profile: Profile;
  public subscribers: Profile[] = [];
  public bloggers: Profile[] = [];

  constructor(
    private profileService: ProfileService,
    private postService: PostService) { }

  private getSubscribers(): void {
    this.profileService.getSubscribers(this.profile.id)
      .subscribe(profiles => this.subscribers = profiles);
  }
  private getBloggers(): void {
    this.profileService.getBloggers(this.profile.id)
      .subscribe(profiles => this.bloggers = profiles);
  }

  ngOnInit() { 
  }

  ngAfterViewInit() {
    this.getSubscribers();
    this.getBloggers();
  }
}
