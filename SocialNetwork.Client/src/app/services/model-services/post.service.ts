import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { NewPost } from '../../models/newPost';
import { Post } from '../../models/post';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class PostService {

  constructor(private http: HttpClient) { }

 public getPosts(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>('http://localhost:5000/api/posts?authorId=' + profileId.toString());
  }
  public getPostsByPage(profileId: number, page: number): Observable<Post[]> {
    return this.http.get<Post[]>('http://localhost:5000/api/posts/postsByPage?authorId=' + profileId.toString() + '&page=' + page.toString());
  }
  public getNews(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>('http://localhost:5000/api/posts/news/?id=' + profileId.toString());
  }
  public getNewsByPage(profileId: number, page: number): Observable<Post[]>{
    return this.http.get<Post[]>('http://localhost:5000/api/posts/newsByPage/?id=' + profileId.toString() + '&page=' + page.toString());
  }
  public addPost(post: NewPost): Observable<NewPost> {
    return this.http.post<NewPost>('http://localhost:5000/api/posts', post, httpOptions);
      // .pipe(
      //   catchError(this.handleError('addHero', post))
      // );
  }

  // private extractData(res: Response) {
  //   const body = res.json();
  //   return body || {};
  // }
  // private handleErrorObservable(error: Response | any) {
  //   console.error(error.message || error);
  //   return Observable.throw(error.message || error);
  // }
}
