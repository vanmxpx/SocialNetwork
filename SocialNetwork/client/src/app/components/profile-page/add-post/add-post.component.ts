import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../../../models/profile';
import { PostService } from '../../../services/model-services/post.service';
import { Post } from '../../../models/post';

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
  private recievedPost: Post;
  private done = false;
  constructor(private postService: PostService) { }

  // addPost(text: string) {
  //   if (text) {
  //     this.postService.addPost(text)
  //       .subscribe(
  //         (data: Post) => { this.recievedPost = data; this.done = true; },
  //         error => console.log(error)
  //       );
  //   }
  // }

  ngOnInit() {
  }

}
