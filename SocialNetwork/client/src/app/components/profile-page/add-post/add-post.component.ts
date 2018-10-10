import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../../../models/profile';
import { PostService } from '../../../services/model-services/post.service';
import { NewPost } from '../../../models/newPost';
import { AddpostService } from '../../../services/addpost-services/addpost.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss'],
})
export class AddPostComponent implements OnInit {
  @Input() public profile: Profile;
  private recievedPost: NewPost;
  constructor(private postService: PostService,
    private router: Router,
    private addNewPostService: AddpostService) { }

  addPost(text: string) {
    const newPost = {
      profileRef: this.profile.id,
      text: text
    };
    if (text) {
      this.postService.addPost(newPost)
        .subscribe(
          (data: NewPost) => {
            this.recievedPost = data;
            const post = {
              id:  this.profile.id,
              text: text,
              datetime: new Date(),
              profile: this.profile
          };

          this.addNewPostService.addPost(post);
    },
    error => console.log(error)
        );
  }
}

ngOnInit() {
}

}
