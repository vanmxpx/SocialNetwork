import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from './services/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './components/header/header.component';
import { UserInfoComponent } from './components/profile-page/user-info/user-info.component';
import { PostComponent } from './components/profile-page/post/post.component';
import { UserPageComponent } from './components/profile-page/user-page/user-page.component';
import { FollowersComponent } from './components/profile-page/followers/followers.component';
import { UserTabsComponent } from './components/profile-page/user-tabs/user-tabs.component';
import { RegistrationComponent } from './components/registration-form/registration-form.component';
import { AppRoutingModule } from './modules/app-routing.module';
import { MaterialModule } from './modules/material/material.module';
import { PostService } from './services/model-services/post.service';
import { ProfileService } from './services/model-services/profile.service';
import { InputDataValidatorService } from './services/validators/input-data-validator.service';
import { AddPostComponent } from './components/profile-page/add-post/add-post.component';


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
    AddPostComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    PostService,
    ProfileService,
    InputDataValidatorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
