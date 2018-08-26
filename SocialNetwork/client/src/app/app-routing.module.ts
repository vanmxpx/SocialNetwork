import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPageComponent } from './user-page/user-page.component';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'profile/quis', pathMatch: 'full',  runGuardsAndResolvers: 'always' },
  {
    path: 'profile/:login',
    component: UserPageComponent,
    runGuardsAndResolvers: 'always'
  },
];


@NgModule({
  imports: [ RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }