import { Component, OnInit, Output, Input, EventEmitter, OnDestroy, AfterViewInit } from '@angular/core';
import { Post } from '../../../models/post';
import { PostService } from '../../../services/model-services/post.service';
import { NotifyService } from '../../../services/notify-services/notify.service';
import { AddpostService } from '../../../services/addpost-services/addpost.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit, OnDestroy, AfterViewInit {
  posts: Post[] = [];
  @Input() public isNews: boolean;
  @Input() public profileId: number;
  page: number;

  public eventAddPost;

  constructor(private postService: PostService,
    private notifyService: NotifyService,
    private addNewPostService: AddpostService) {
    this.page = 0;
  }
  ngOnInit() {
  }

  private getPostsByPage(): void {
    this.postService.getPostsByPage(this.profileId, this.page)
      .subscribe((res) => this.onPostsSuccess(res));
  }
  private getNewsByPage(): void {
    this.postService.getNewsByPage(this.profileId, this.page)
      .subscribe((res) => this.onPostsSuccess(res));
  }

  onPostsSuccess(res) {
    // console.log("Post page " + this.page);
    // console.log(res);
    if (res !== undefined) {
      res.forEach(item => {
        this.posts.push(item);
      });
    }
  }

  onScroll() {
    this.page = this.page + 1;
    if (this.isNews === true) {
      this.getNewsByPage();
    } else {
      this.getPostsByPage();
    }
    // console.log("Scrolled down");
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngAfterViewInit() {

    if (this.isNews) {
      this.getNewsByPage();
      this.eventAddPost = this.notifyService.newPostReceived.subscribe((post: Post) => {
        this.posts.unshift(post);
      });
    } else {
      this.getPostsByPage();
      this.eventAddPost = this.addNewPostService.addNewPost.subscribe((post: Post) => {
        this.posts.unshift(post);
      });
    }

    this.page = this.page + 1;
  }

  ngOnDestroy() {
      this.eventAddPost.unsubscribe();
  }
}
