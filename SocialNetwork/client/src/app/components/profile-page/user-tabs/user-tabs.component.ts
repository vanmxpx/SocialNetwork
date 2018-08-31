import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../../../models/profile';
import { ProfileService } from '../../../services/model-servies/profile.service';
import { PostService } from '../../../services/model-servies/post.service';
import { Post } from '../../../models/post';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit {
  @Input() profile: Profile;
  posts: Post[];
  news: Post[];
  subscribers: Profile[];
  bloggers: Profile[];
  getSubscribers(): void {
    this.profileService.getSubscribers(this.profile.id)
      .subscribe(profiles => this.subscribers = profiles);
  }
  getBloggers(): void {
    this.profileService.getBloggers(this.profile.id)
      .subscribe(profiles => this.bloggers = profiles);
  }
  getPosts(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
  }
  getNews(): void {
    this.postService.getNews(this.profile.id)
      .subscribe(news => this.news = news);
  }
  constructor(
    private profileService: ProfileService,
    private postService: PostService) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.getPosts();
    this.getSubscribers();
    this.getBloggers();
    this.getNews();
  }
}
