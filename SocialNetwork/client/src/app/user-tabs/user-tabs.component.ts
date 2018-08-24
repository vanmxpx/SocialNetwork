import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../models/profile';
import { PostService } from '../post.service';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit {
  @Input()profile: Profile;
  followersList: Profile[];
  followingsList: Profile[];
  getFollowers(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
  }
  getFollowings(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
  }
  constructor(private postService: PostService) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.getPosts();
  }

}
