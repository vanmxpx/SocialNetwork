import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../../../models/profile';
import { Post } from '../../../models/post';
import { ProfileService } from '../../../services/model-services/profile.service';
import { PostService } from '../../../services/model-services/post.service';

@Component({
  selector: 'app-user-tabs',
  templateUrl: './user-tabs.component.html',
  styleUrls: ['./user-tabs.component.scss']
})
export class UserTabsComponent implements OnInit {
  public isAuthorizedUserProfile: boolean;
  @Input() public profile: Profile;
  public posts: Post[];
  public news: Post[];
  public subscribers: Profile[];
  public bloggers: Profile[];

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
  private getPosts(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
  }
  private getNews(): void {
    this.postService.getNews(this.profile.id)
      .subscribe(news => this.news = news);
  }
  private checkOnMine(): void {
    this.isAuthorizedUserProfile = (localStorage.getItem('login') === JSON.stringify(this.profile.login)) ? true : false;
  }


  ngOnInit() {
    this.checkOnMine();
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngAfterViewInit() {
    this.getPosts();
    this.getSubscribers();
    this.getBloggers();
    this.getNews();
  }
}
