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
  public posts: Post[] = [];
  public news: Post[] = [];
  public subscribers: Profile[] = [];
  public bloggers: Profile[] = [];
  postsPage: number = 1;
  newsPage: number = 1;
  status: number = 0;

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
  private getPostsByPage(): void {
    this.postService.getPostsByPage(this.profile.id, this.postsPage)
      .subscribe((res) => this.onPostsSuccess(res));
  }
  private getNewsByPage(): void {
    this.postService.getNewsByPage(this.profile.id, this.newsPage)
      .subscribe((res) => this.onNewsSuccess(res));
  }

  onPostsSuccess(res) {
    console.log("Post page" + this.postsPage);
    console.log(res);
    if (res != undefined) {
      res.forEach(item => {
        this.posts.push(item);
      });
    }
  }

  onNewsSuccess(res) {
    console.log("News page" + this.newsPage);
    console.log(res);
    if (res != undefined) {
      res.forEach(item => {
        this.news.push(item);
      });
    }
  }


  ngOnInit() { 
  }

  onScroll()  
  {  
    console.log("Scrolled");
    switch(+this.status)
    {
      case 0:
        this.postsPage = this.postsPage + 1;
        this.getPostsByPage();
        break;
      case 3:
        this.newsPage = this.newsPage + 1;
        this.getNewsByPage();
        break;
    }
  } 

  // tslint:disable-next-line:use-life-cycle-interface
  ngAfterViewInit() {
    this.getPostsByPage();
    this.getSubscribers();
    this.getBloggers();
    this.getNewsByPage();
  }

  onOtherTabClick(event: MatTabChangeEvent) {
    this.status = event.index;
    //this.page = 1;
  }
}
