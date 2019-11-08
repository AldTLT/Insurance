import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Authorization } from 'src/app/models/authorization';
import { BinaryOperatorExpr } from '@angular/compiler';
import { HttpErrorResponse } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers: [AuthService, RouterModule]
})
export class AuthComponent implements OnInit {

  isLoginError: boolean = false;
  data: Authorization = new Authorization();

  constructor(
    private authService: AuthService, 
    private storeService: StoreService, 
    private router: Router
    ) 
    {
    this.data.password = "qwerty123";
    this.data.username = "test@mail.ru";
  }

  ngOnInit() {
  }

  onSubmit(email: string, password: string){

  }

  signIn(authData: Authorization){
    this.authService.authorization(authData).subscribe((data:any) => {
      //Сохранение e-mail
      this.storeService.setItem('email', authData.username); //Получение данных не работает
      localStorage.setItem('email', authData.username);
      //Сохранение токена
      localStorage.setItem('token', data.access_token);
      this.router.navigate(['/personal'])
    },
    (err: HttpErrorResponse) => {
      this.isLoginError = true;
    });
  }
}
