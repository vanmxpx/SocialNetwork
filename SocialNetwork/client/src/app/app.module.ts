import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PostComponent } from './post/post.component';
import { LoginComponent} from './login/login.component';
import { AlertComponent } from './directives';
import { AuthGuard } from './guards';
import { JwtInterceptor, ErrorInterceptor } from './helpers';
import { AlertService, AuthenticationService } from './services';
import { UserPageComponent } from './user-page/user-page.component';
import { FollowersComponent } from './followers/followers.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { UserTabsComponent } from './user-tabs/user-tabs.component';
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
    AlertComponent,
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
