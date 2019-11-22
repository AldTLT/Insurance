import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';
import { HttpErrorResponse } from '@angular/common/http';
import { StoreService } from 'src/app/services/store.service';
import { ChangePass } from 'src/app/models/changepass';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss']
})
//Класс представляет компонент вывода данных пользователя.
export class DataComponent implements OnInit {

  constructor(private authService: AuthService, private storeService: StoreService) { }

  email: string;
  user: User = new User;
  GetItemError: boolean = false;
  ChangePasswordError: boolean = false;  
  changePasswordModel: ChangePass = new ChangePass();
  toChange: boolean = false;
  success: boolean;

  isOldPasswordCorrect: boolean;
  isNewPasswordCorrect: boolean;
  isConfirmPasswordCorrect: boolean;

  oldPasswordColor: string;
  newPasswordColor: string;
  confirmPasswordColor: string;

  ngOnInit() {
    this.email = this.storeService.getItem('email');

    this.authService.getUser(this.email).subscribe((data: any) => {
      this.user.EMail = data.EMail;
      this.user.Name = data.Name;
      this.user.BirthDate = data.BirthDate;
      this.user.DriverLicenseDate = data.DriverLicenseDate;
      console.log(data);
    },    
    (err: HttpErrorResponse) => {
      this.GetItemError = true;
    });
  }

  //Метод возвращает true если строка пустая, иначе - false.
  isEmpty(data: string): boolean {
    return !data || data.length === 0;
  }

  //Метод возвращает true если строка пустая, или длинна строки не находится между minLength и maxLength.
  isShort(data: string, minLength: number, maxLength: number): boolean{
    return this.isEmpty(data) ? true : !(data.length >= minLength && data.length <= maxLength);
  }  

  //Проверка старого пароля.
  checkOldPassword(){
    this.isOldPasswordCorrect = !this.isShort(this.changePasswordModel.OldPassword, 6, 20);
    this.oldPasswordColor = this.isOldPasswordCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

    //Инициализация цвета фона поля.
    initializeOldPassword(){
      this.oldPasswordColor = 'rgb(240, 240, 240)';
    }

  //Проверка нового пароля.
  checkNewPassword(){
    this.isNewPasswordCorrect = 
    !this.isShort(this.changePasswordModel.NewPassword, 6, 20)
    && !this.isShort(this.changePasswordModel.ConfirmPassword, 6, 20)
    && this.changePasswordModel.NewPassword == this.changePasswordModel.ConfirmPassword;
    this.newPasswordColor = this.isNewPasswordCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

    //Инициализация цвета фона поля.
    initializeNewPassword(){
      this.newPasswordColor = 'rgb(240, 240, 240)';
      this.checkConfirmPassword();
    }

  checkConfirmPassword(){
    this.isConfirmPasswordCorrect = 
    !this.isEmpty(this.changePasswordModel.ConfirmPassword)
    && this.changePasswordModel.ConfirmPassword == this.changePasswordModel.NewPassword;
  }

  //Метод смены пароля.
  changePassword(){
    this.checkOldPassword();
    this.checkNewPassword();
    this.checkConfirmPassword();

    if (
      this.isOldPasswordCorrect 
      && this.isNewPasswordCorrect 
      && this.changePasswordModel.NewPassword == this.changePasswordModel.ConfirmPassword
      )
    {
      this.authService.changePassword(this.email, this.changePasswordModel).subscribe((data: boolean) => {
        this.ChangePasswordError = !data;
        this.success = data;        
        this.toChange = data ? false : this.toChange;
      })
    }
  }  
}
