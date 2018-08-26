import { NgModule } from '@angular/core';
import { UserPageComponent } from './user-page/user-page.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', redirectTo: 'profile/quis', pathMatch: 'full',  runGuardsAndResolvers: 'always' },
  { path: 'profile/:login', component: UserPageComponent, runGuardsAndResolvers: 'always'},
  { path: 'login', component: LoginComponent}
];


@NgModule({
  imports: [ RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }