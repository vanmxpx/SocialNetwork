import { Component, OnInit, Output, Input, EventEmitter, AfterViewInit } from '@angular/core';
import { Post } from '../../../models/post';
import { PostService } from '../../../services/model-services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit, AfterViewInit {
  posts: Post[] = [];
  @Input() public isNews: boolean;
  @Input() public profileId: number;
  page = 0;

  constructor(private postService: PostService) { }

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
    console.log('Post page ' + this.page);
    console.log(res);
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
    console.log('Scrolled down');
  }

  ngAfterViewInit() {
    if (this.isNews === true) {
      this.getNewsByPage();
    } else {
      this.getPostsByPage();
    }
    this.page = this.page + 1;
  }
}
