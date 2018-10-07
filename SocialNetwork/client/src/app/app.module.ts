import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { UserInfoComponent } from './components/profile-page/user-info/user-info.component';
import { PostComponent } from './components/profile-page/post/post.component';
import { FollowersComponent } from './components/profile-page/followers/followers.component';
import { UserTabsComponent } from './components/profile-page/user-tabs/user-tabs.component';
import { PostService } from './services/model-services/post.service';
import { ProfileService } from './services/model-services/profile.service';
import { AddPostComponent } from './components/profile-page/add-post/add-post.component';
import { LoginComponent } from './components/login/login.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { MaterialModule } from './modules/material/material.module';
import { AuthenticationService } from './services/security/authentication.service';
import { RegistrationComponent } from './components/registration-form/registration-form.component';
import { UserPageComponent } from './components/profile-page/user-page/user-page.component';
import { JwtInterceptor, ErrorInterceptor } from './helpers';
import { AppComponent } from './app.component';
import { AuthGuard } from './guards';
import { FooterComponent } from './components/footer/footer.component';
import { FollowingsService } from './services/model-services/followings.service';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { NotifyService } from './services/notify-services/notify.service';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UserInfoComponent,
    PostComponent,
    UserPageComponent,
    FollowersComponent,
    UserTabsComponent,
    RegistrationComponent,
    AddPostComponent,
    LoginComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    InfiniteScrollModule
  ],
  providers: [
    AuthGuard,
    PostService,
    ProfileService,
    AuthenticationService,
    FollowingsService,
    NotifyService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
