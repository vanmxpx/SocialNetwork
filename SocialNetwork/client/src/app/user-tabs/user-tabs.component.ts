import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../models/profile';
import { PostService } from '../post.service';
import { Post } from '../models/post';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit {
  @Input() profile: Profile;
  @Input() posts: Post[];
  subscribers: Profile[];
  bloggers: Profile[];
  getSubscribers(): void {
    this.postService.getSubscribers(this.profile.id)
      .subscribe(profiles => this.subscribers = profiles);
  }
  getBloggers(): void {
    this.postService.getBloggers(this.profile.id)
      .subscribe(profiles => this.bloggers = profiles);
  }
  constructor(private postService: PostService) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.getSubscribers();
    this.getBloggers();
  }

}
