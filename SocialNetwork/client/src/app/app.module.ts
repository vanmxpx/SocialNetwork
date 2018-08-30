import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './services/app.component';
import { HeaderComponent } from './components/header/header.component';
import { UserInfoComponent } from './components/profile-page/user-info/user-info.component';
import { PostComponent } from './components/profile-page/post/post.component';
import { FollowersComponent } from './components/profile-page/followers/followers.component';
import { UserTabsComponent } from './components/profile-page/user-tabs/user-tabs.component';
import { PostService } from './services/model-services/post.service';
import { ProfileService } from './services/model-services/profile.service';
import { InputDataValidatorService } from './validators/input-data-validator.service';
import { AddPostComponent } from './components/profile-page/add-post/add-post.component';
import { LoginComponent } from './components/login/login.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { MaterialModule } from './modules/material/material.module';
import { AuthenticationService } from './services/authentication.service';
import { AlertService } from './services/alert.service';
import { RegistrationComponent } from './components/registration-form/registration-form.component';
import { UserPageComponent } from './components/profile-page/user-page/user-page.component';


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
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    PostService,
    ProfileService,
    InputDataValidatorService,
    AuthenticationService,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
