import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthComponent } from './components/auth/auth.component';
import { RegistrComponent } from './components/registr/registr.component';
import { AuthGuard } from './auth/auth.guard';
import { PersonalComponent } from './components/personal/personal.component';
import { SuccessComponent } from './components/registr/success/success.component';
import { BuypolicyComponent } from './components/personal/buypolicy/buypolicy.component';
import { DataComponent } from './components/personal/data/data.component';
import { PoliciesComponent } from './components/personal/policies/policies.component';
import { PayComponent } from './components/personal/pay/pay.component';
import { CalcGuard } from './auth/calc.guard';

export const routes: Routes = [
  { path: 'personal', component: PersonalComponent, canActivate: [AuthGuard], 
    children: [
      { path: 'buypolicy', component: BuypolicyComponent},
      { path: 'pay', component: PayComponent, canActivate: [CalcGuard] },
      { path: 'data', component: DataComponent},
      { path: 'policies', component: PoliciesComponent}
    ]},
    
  { path: 'authorization', component: AuthComponent},
  { path: 'registration', component: RegistrComponent,
    children: [{ path: 'success', component: SuccessComponent }]
  },
  { path: '', redirectTo: '/authorization', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
