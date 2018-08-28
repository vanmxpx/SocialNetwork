import { Component, OnInit, Input } from '@angular/core';
import { Post } from '../../../models/post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  @Input() public posts: Post[];
  constructor() { }

  ngOnInit() {

  }
}
