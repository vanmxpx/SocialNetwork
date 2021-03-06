import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserPageComponent } from '../components/profile-page/user-page/user-page.component';
import { RegistrationComponent } from '../components/registration-form/registration-form.component';
import { LoginComponent } from '../components/login/login.component';
import { AuthGuard } from '../guards';
import { SettingsComponent } from '../components/settings/settings.component';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full', runGuardsAndResolvers: 'always', canActivate: [AuthGuard] },
  { path: 'profile/:login', component: UserPageComponent, runGuardsAndResolvers: 'always', canActivate: [AuthGuard] },
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent, runGuardsAndResolvers: 'always'},
  { path: 'login/:email/:password', component: LoginComponent},
  { path: 'settings', component: SettingsComponent, runGuardsAndResolvers: 'always', canActivate: [AuthGuard]}
//  { path: '**', pathMatch: 'full', component: PathNotFoundComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
