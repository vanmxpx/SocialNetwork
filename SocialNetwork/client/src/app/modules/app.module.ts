import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from '../app.component';
import { HeaderComponent } from '../components/header/header.component';
import { UserInfoComponent } from '../components/profile-page/user-info/user-info.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PostComponent } from '../components/profile-page/post/post.component';
import { LoginComponent} from '../login/login.component';
import { AuthGuard } from '../guards';
import { JwtInterceptor, ErrorInterceptor } from '../helpers';
import { AlertService, AuthenticationService } from '../services';
import { UserPageComponent } from '../components/profile-page/user-page/user-page.component';
import { FollowersComponent } from '../components/profile-page/followers/followers.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { UserTabsComponent } from '../components/profile-page/user-tabs/user-tabs.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppRoutingModule } from './app-routing.module';
import { MatMenuModule } from '@angular/material/menu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UserInfoComponent,
    PostComponent,
    UserPageComponent,
    FollowersComponent,
    LoginComponent,
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
    AppRoutingModule,
    FlexLayoutModule,
    MatMenuModule,    
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthGuard,
    AlertService,
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
