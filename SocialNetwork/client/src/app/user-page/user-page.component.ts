import { Component, OnInit, Input } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { PostService } from '../post.service';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  profile: Profile;
  getProfile(): void {
    this.postService.getProfile()
      .subscribe(profile => this.profile = profile);
  }
  @Input() color: ThemePalette;

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.getProfile();
  }

}
