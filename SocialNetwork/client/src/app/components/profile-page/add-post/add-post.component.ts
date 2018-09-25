import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { Profile } from '../../../models/profile';
import { PostService } from '../../../services/model-services/post.service';
import { NewPost } from '../../../models/newPost';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent implements OnInit {
  @Input() public profile: Profile;
  private recievedPost: NewPost;
  constructor(private postService: PostService,
    private router: Router) { }

  addPost(text: string) {
    const newPost = {
      profileRef: this.profile.id,
      text: text
    };
    if (text) {
      this.postService.addPost(newPost)
        .subscribe(
          // (data: NewPost) => {
          //   this.recievedPost = data;
          //   this.router.navigateByUrl('/profile/' + this.profile.login);
          // },
          // error => console.log(error)
        );
    }
  }

  ngOnInit() {
  }

}
