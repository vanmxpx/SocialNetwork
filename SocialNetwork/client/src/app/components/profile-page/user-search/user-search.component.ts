import { Component, OnInit } from '@angular/core';
import { Profile } from '../../../models/profile';
import { ProfileService } from '../../../services/model-services/profile.service';

@Component({
  selector: 'app-user-search',
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.scss']
})
export class UserSearchComponent implements OnInit {
  public profiles: Profile[] = [];
  public SearchString: string;
  public loading: boolean;
  constructor(private profileService: ProfileService) { }

  ngOnInit() {  }
  SearchClick() {
    this.profiles = [];
    this.recieveProfiles();
  }
  onScroll() {
    console.log('scroll');
    this.recieveProfiles();
  }
  private recieveProfiles() {
    if (this.SearchString !== undefined && this.SearchString !== null && this.SearchString !== '') {
      this.loading = true;
      console.log('hello: ' + this.SearchString);
      this.profileService.getProfiles(this.SearchString, this.profiles.length, this.profiles.length + 6)
        .subscribe((res) => {
          if (res !== undefined && res !== null) {
            res.forEach(item => {
              this.profiles.push(item);
            });
            this.loading = false;
          }
        },
          error => {
            this.loading = false;
          });
    }
  }
}
