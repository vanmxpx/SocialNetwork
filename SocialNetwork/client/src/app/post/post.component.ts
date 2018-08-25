import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../models/post';
import { Profile } from '../models/profile';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  @Input() posts: Post[];
  constructor() { }

  ngOnInit() {
    
  }
}
