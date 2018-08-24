import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '../../node_modules/@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PostComponent } from './post/post.component';
import { UserPageComponent } from './user-page/user-page.component';
import { FollowersComponent } from './followers/followers.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { UserTabsComponent } from './user-tabs/user-tabs.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { AppRoutingModule } from './/app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UserInfoComponent,
    PostComponent,
    UserPageComponent,
    FollowersComponent,
    UserTabsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HeaderComponent,
    BrowserAnimationsModule,
    MatGridListModule,
    MatTabsModule,
    MatListModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
