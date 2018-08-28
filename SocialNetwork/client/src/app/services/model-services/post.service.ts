import { Injectable } from '@angular/core';
import { Post } from '../../models/post';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable()
export class PostService {
  getPosts(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>('http://localhost:5000/api/posts?authorId=' + profileId.toString());
  }
  getNews(profileId: number): Observable<Post[]> {
    return this.http.get<Post[]>('http://localhost:5000/api/posts/news/?id=' + profileId.toString());
  }
  addPost(post: Post, id: number): Observable<Post> {
    return this.http.post<Post>('http://localhost:5000/api/posts', post, httpOptions);
      // .pipe(
      //   catchError(this.handleError('addHero', post))
      // );
  }

  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    const body = res.json();
    return body || {};
  }
  private handleErrorObservable(error: Response | any) {
    console.error(error.message || error);
    return Observable.throw(error.message || error);
  }
}
