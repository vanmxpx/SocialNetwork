import { Component, OnInit, Input } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../models/post';
import { Profile } from '../models/profile';
import { InvokeFunctionExpr } from '@angular/compiler';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  @Input() profile: Profile;
  @Input() posts: Post[];
  constructor() { }

  ngOnInit() {
    
  }

  ngAfterViewInit() {
  }
}
