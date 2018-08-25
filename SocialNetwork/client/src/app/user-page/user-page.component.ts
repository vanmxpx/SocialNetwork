import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { PostService } from '../post.service';
import { Profile } from '../models/profile';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
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
  getProfile(): void {
    this.login = this.route.snapshot.paramMap.get('login');
    this.profileService.getProfile(this.login)
      .subscribe(profile => this.profile = profile);
  }
  getPosts(): void {
    this.postService.getPosts(this.profile.id)
      .subscribe(posts => this.posts = posts);
  }
  @Input() color: ThemePalette;



  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private postService: PostService,
    private profileService: ProfileService
  ) {
    // override the route reuse strategy
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    }

    this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
        // trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
        // if you need to scroll back to top, here is the right place
        window.scrollTo(0, 0);
      }
    });
  }

  ngOnInit() {
    this.getProfile();
  }

  initialiseInvites() {
    this.getProfile();
  }

  ngAfterViewInit() {
    this.getPosts();
  }
}
