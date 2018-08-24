import { Component, OnInit, Input } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../models/post';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  @Input() profileId: number;
  posts: Post[];
  getPosts(): void {
    this.postService.getPosts(this.profileId)
      .subscribe(posts => this.posts = posts);
  }
  constructor(private postService: PostService) { }

  ngOnInit() {
    this.getPosts();
  }

}
