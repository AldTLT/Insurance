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

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  signIn(authData: Authorization){
    this.authService.authorization(authData).subscribe((data:any) => {
      localStorage.setItem('userToken', data.access_token);
      this.router.navigate(['/home'])
    },
    (err: HttpErrorResponse) => {
      this.isLoginError = true;
    });
  }
}
