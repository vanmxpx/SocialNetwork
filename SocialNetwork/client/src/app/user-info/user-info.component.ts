import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Profile } from '../models/profile';



@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  profile: Profile;
  getProfile(): void{
    this.postService.getProfile()
    .subscribe(profile => this.profile = profile);
  }
  constructor(private postService: PostService) { }

  ngOnInit() {
    this.getProfile();
  }

}
