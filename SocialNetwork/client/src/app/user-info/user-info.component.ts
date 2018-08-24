import { Component, OnInit, Input } from '@angular/core';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  @Input()profile: Profile;
  constructor() { }

  ngOnInit() {
  }
}
