import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPageComponent } from './user-page/user-page.component';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration-form/registration-form.component';


const routes: Routes = [
  { path: '', redirectTo: 'profile/quis', pathMatch: 'full',  runGuardsAndResolvers: 'always' },
  {
    path: 'profile/:login',
    component: UserPageComponent,
    runGuardsAndResolvers: 'always'
  },
  { path: 'registration', component: RegistrationComponent }
];


@NgModule({
  imports: [ RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }