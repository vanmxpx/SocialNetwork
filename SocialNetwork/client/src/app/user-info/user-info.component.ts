import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  name: string = "John";
  lastName: string = "Doe";
  login: string = "jestro";
  userInfo: string = "yyyyyyyy djglkdjklgjlfkdjglkjfldkgjlk fgkdgjkldfjglkjdfklgjklfjdgkljdfkljgk;ldfjgijerioghklchjd  gdfghkdfjglk dfjglkdfj lkjdfg kljfgkl jdfkljglkdfjgklj dflkjgkl djfgkl jdlfkgj lkf gjlkgdj lkdfj lkjdf lkjg dlkjg lkdf";
  constructor() { }

  ngOnInit() {
  }

}
