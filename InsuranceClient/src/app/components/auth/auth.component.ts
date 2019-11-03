import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Authorization } from 'src/app/models/authorizationData';
import { BinaryOperatorExpr } from '@angular/compiler';
import { HttpErrorResponse } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers: [AuthService, RouterModule]
})
export class AuthComponent implements OnInit {

  isLoginError: boolean = false;
  data: Authorization = new Authorization();

  constructor(private authService: AuthService, private router: Router) {
    this.data.password = "qwerty123";
    this.data.username = "test@mail.ru";
   }

  ngOnInit() {
  }

  onSubmit(email: string, password: string){

  }

  signIn(authData: Authorization){
    this.authService.authorization(authData).subscribe((data:any) => {
      localStorage.setItem('token', data.access_token);
      localStorage.setItem('email', data.email);
      console.log(localStorage.getItem('email'));
      this.router.navigate(['/personal'])
    },
    (err: HttpErrorResponse) => {
      this.isLoginError = true;
    });
  }
}
