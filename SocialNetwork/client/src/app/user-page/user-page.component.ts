import { Component, OnInit, Input } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { PostService } from '../post.service';
import { Profile } from '../models/profile';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Post } from '../models/post';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  profile: Profile;
  posts: Post[];
  login: string;
  gridHeight: number;
  getProfile(): void {
    this.login = this.route.snapshot.paramMap.get('login');
    this.profileService.getProfile(this.login)
      .subscribe(profile => this.profile = profile);
  }
  getPosts(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
    this.gridHeight = this.posts.length*100;
  }
  @Input() color: ThemePalette;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private postService: PostService,
    private profileService: ProfileService
  ) { }

  ngOnInit() {
    this.getProfile();
    
  }

  ngAfterViewInit() {
    this.getPosts();
  }

}
