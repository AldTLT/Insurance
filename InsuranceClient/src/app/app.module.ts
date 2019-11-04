import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './components/auth/auth.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { RegistrComponent } from './components/registr/registr.component';
import { routes } from './app-routing.module';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { PersonalComponent } from './components/personal/personal.component';
import { SuccessComponent } from './components/registr/success/success.component';
import { PoliciesComponent } from './components/personal/policies/policies.component';
import { DataComponent } from './components/personal/data/data.component';
import { BuypolicyComponent } from './components/personal/buypolicy/buypolicy.component';
import { PolicyComponent } from './components/personal/policies/policy/policy.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    HomeComponent,
    RegistrComponent,
    PersonalComponent,
    SuccessComponent,
    PoliciesComponent,
    DataComponent,
    BuypolicyComponent,
    PolicyComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthGuard,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent, ]
})
export class AppModule { }
