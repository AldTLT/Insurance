import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { ClientName } from 'src/app/models/clientname';

@Component({
  selector: 'app-registr',
  templateUrl: './registr.component.html',
  styleUrls: ['./registr.component.scss']
})
export class RegistrComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) {

    // this.userData.EMail = "vr0rtex@mail.ru";
    // this.clientName.name = "Vasiliy";
    // this.clientName.surname = "Pupkin";
    // this.clientName.patronymic = "Ivanovich";
    // this.userData.BirthDate = new Date(1980, 1, 1, 0, 0, 0, 0);
    // this.userData.DriverLicenseDate = new Date(2010, 2, 2, 0, 0, 0, 0);
    // this.userData.Password = "qwerty123456";
    // this.confirmPassword = "qwerty123456";
  }

  userData: User = new User();
  isDataCorrect: boolean = true;
  registerResult: boolean = false;
  clientName: ClientName = new ClientName(); 
  confirmPassword: string;

  isEmailCorrect: boolean;
  isPasswordCorrect: boolean;
  isNameCorrect: boolean;
  isSurnameCorrect: boolean;
  isPatronymicCorrect: boolean;
  isBirthDateCorrect: boolean;
  isDriverLicenseDateCorrect: boolean;

  emailColor: string;
  nameColor: string;
  surnameColor: string;
  patronimycColor: string;
  bithDateColor: string;
  driverLicenzeDateColor: string;
  passwordColor: string;

  ngOnInit() {
  }

  //Метод возвращает true если строка пустая, иначе - false.
  isEmpty(data: string): boolean {
    return !data || data.length === 0;
  }

  //Метод возвращает true если строка пустая, или длинна строки не находится между minLength и maxLength.
  isShort(data: string, minLength: number, maxLength: number): boolean{
    return this.isEmpty(data) ? true : !(data.length >= minLength && data.length <= maxLength);
  }

  //Метод проверки e-mail.
  checkEmail(){
    this.isEmailCorrect = !this.isShort(this.userData.EMail, 5, 30);
    this.emailColor = this.isEmailCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializeEmail(){
    this.emailColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки имени.
  checkName(){
    this.isNameCorrect = !this.isShort(this.clientName.name, 2, 20);
    this.nameColor = this.isNameCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializeName(){
    this.nameColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки фамилии.
  checkSurname(){
    this.isSurnameCorrect = !this.isShort(this.clientName.surname, 2, 20);
    this.surnameColor = this.isSurnameCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializeSurname(){
    this.surnameColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки отчества.
  checkPatronimyc(){
    this.isPatronymicCorrect = !this.isShort(this.clientName.patronymic, 2, 20);
    this.patronimycColor = this.isPatronymicCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializePatronimyc(){
    this.patronimycColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки даты рождения.
  checkBirthDate(){
    let birthDate = new Date(this.userData.BirthDate);
    let today = new Date();
    //Минимальный возраст для регистрации в системе - 12 лет.
    const age = 12;
    this.isBirthDateCorrect = this.getYears(today, birthDate) > age;
    this.bithDateColor = this.isBirthDateCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializeBirthDate(){
    this.bithDateColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки даты выдачи водительских прав.
  checkDriverLicenseDate(){
    let driverDate = new Date(this.userData.DriverLicenseDate);
    let birthDate = new Date(this.userData.BirthDate);
    //Минимальный возраст получения прав - 10 лет.
    const age = 10; 
    this.isDriverLicenseDateCorrect = this.getYears(driverDate, birthDate) >  age;
    this.driverLicenzeDateColor = this.isDriverLicenseDateCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializeDriverLicenseDate(){
    this.driverLicenzeDateColor = 'rgb(240, 240, 240)';
  }
  

  //Метод возвращает true если пароль и подтверждение пароля больше 6 символов и совпадают, иначе - false.
  checkPassword(){
    this.isPasswordCorrect = 
      !this.isShort(this.userData.Password, 6, 20)
      && !this.isShort(this.confirmPassword, 6, 20)
      && this.userData.Password == this.confirmPassword;
      this.passwordColor = this.isPasswordCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

  //Инициализация цвета фона поля.
  initializePassword(){
    this.passwordColor = 'rgb(240, 240, 240)';
  }

  //Метод возвращает разницу в годах между двумя датами (firstDate - secondDate).
  getYears(firstDate: Date, secondDate: Date): number{
    let years = firstDate.getFullYear() - secondDate.getFullYear();
    return years;
  }

  userRegistration(){
    this.isDataCorrect = true;

    this.checkEmail();
    this.checkName();
    this.checkSurname();
    this.checkPatronimyc();
    this.checkBirthDate();
    this.checkDriverLicenseDate();
    this.checkPassword();

    if (
      !this.isEmailCorrect
      || !this.isNameCorrect
      || !this.isSurnameCorrect
      || !this.isPatronymicCorrect
      || !this.isBirthDateCorrect
      || !this.isDriverLicenseDateCorrect
      || !this.isPasswordCorrect
      )
    {
      this.isDataCorrect = false;
    }
    else
    {
      this.userData.Name = this.clientName.getFullName();
      this.authService.register(this.userData).subscribe((data: any) => {
        this.registerResult = data;
        if (this.registerResult)
        {
          this.router.navigate(['/registration/success']);          
        }
      })
    }
  }
}
