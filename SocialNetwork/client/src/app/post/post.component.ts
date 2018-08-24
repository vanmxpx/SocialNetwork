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
  @Input() profile: Profile;
  posts: Post[];
  getPosts(): void {
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
