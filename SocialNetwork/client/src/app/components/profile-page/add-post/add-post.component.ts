import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../../../models/profile';
import { PostService } from '../../../services/model-services/post.service';
import { Post } from '../../../models/post';
import { Router } from '@angular/router';
import { NewPost } from '../../../models/newPost';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
  template: `
    <input #newPost
      (keyup.enter)="addPost(newPost.value)"
       newPost.value=''>

    <button (click)="addPost(newPost.value)">Add</button>
  `
})
export class AddPostComponent implements OnInit {
  @Input() public profile: Profile;
  private recievedPost: NewPost;
  private done = false;
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
          (data: NewPost) => { this.recievedPost = data;
             this.done = true;
            this.router.navigateByUrl('/profile/' + this.profile.login); },
          error => console.log(error)
        );
      
    }
  }

  ngOnInit() {
  }

}
