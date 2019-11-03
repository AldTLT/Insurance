import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthComponent } from './components/auth/auth.component';
import { RegistrComponent } from './components/registr/registr.component';
import { AuthGuard } from './auth/auth.guard';
import { PersonalComponent } from './components/personal/personal.component';


export const routes: Routes = [
  { path: 'personal', component: PersonalComponent, canActivate: [AuthGuard]}, //Если canActivate - true, home доступен
  { path: 'authorization', component: AuthComponent},
  { path: 'registration', component: RegistrComponent},
  { path: '', redirectTo: '/authorization', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
