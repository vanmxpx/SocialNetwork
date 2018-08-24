import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { PostService } from '../post.service';
import { Profile } from '../models/profile';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Post } from '../models/post';
import { ProfileService } from '../profile.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit, OnDestroy {
  profile: Profile;
  posts: Post[];
  login: string;
  navigationSubscription;
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
    // subscribe to the router events - storing the subscription so
    // we can unsubscribe later. 

    this.navigationSubscription = this.router.events.subscribe((e: any) => {
      // If it is a NavigationEnd event re-initalise the component
      if (e instanceof UserPageComponent) {
        this.initialiseInvites();
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

  ngOnDestroy() {
    // avoid memory leaks here by cleaning up after ourselves. If we  
    // don't then we will continue to run our initialiseInvites()   
    // method on every navigationEnd event.
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
    }
  }

}
