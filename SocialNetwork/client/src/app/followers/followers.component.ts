import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-followers',
  templateUrl: './followers.component.html',
  styleUrls: ['./followers.component.scss']
})
export class FollowersComponent implements OnInit {
  @Input() profiles: Profile[];
  constructor() { }

  ngOnInit() {
  }

}
