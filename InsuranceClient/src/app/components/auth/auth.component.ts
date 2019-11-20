import { Component, OnInit, Input, Output } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Authorization } from 'src/app/models/authorization';
import { BinaryOperatorExpr } from '@angular/compiler';
import { HttpErrorResponse } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers: [AuthService, RouterModule]
})
export class AuthComponent implements OnInit {

  //Маркер
  isLoginError: boolean = false;
  //Экземпляр класса Authorization с данными авторизации.
  data: Authorization = new Authorization();
  //Маркер показывающий что пользователь залогинен
  logged: boolean;

  constructor(
    private authService: AuthService, 
    private storeService: StoreService, 
    private dataService: DataService,
    private router: Router
    ){}

  ngOnInit() {    
  }

  signIn(authData: Authorization){
    this.authService.authorization(authData).subscribe((data:any) => {
      //Сохранение e-mail.
      this.storeService.setItem('email', authData.username);
      //Сохранение токена.
      localStorage.setItem('token', data.access_token);
      //Сохранение статуса логгирования для обмена с другими компонентами.
      this.dataService.changeLogStatus(true);
      this.router.navigate(['/personal'])
    },
    (err: HttpErrorResponse) => {
      this.isLoginError = true;
    });
  }
}
