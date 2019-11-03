import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/userdata';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-registr',
  templateUrl: './registr.component.html',
  styleUrls: ['./registr.component.scss']
})
export class RegistrComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) {

    this.userData.email = "test2@mail.ru";
    this.userData.name = "Vasya";
    this.userData.birthDate = new Date(1980, 1, 1, 0, 0, 0, 0);
    this.userData.driverLicenseDate = new Date(2010, 2, 2, 0, 0, 0, 0);
    this.userData.password = "qwerty123456";
  }

  userData: User = new User();
  isRegisterError: boolean = false;
  registerResult: boolean = false;

  ngOnInit() {
  }

  //Проверка коректности введенных данных
  checkData(){

  }

  userRegistration(user: User){
    this.authService.register(user).subscribe((data: any) => {
      this.registerResult = data;
      console.log(data);
      if (data == true)
      this.router.navigate(['/registration/success']),

      (err: HttpErrorResponse) => {
      this.isRegisterError = true;
      console.log(this.isRegisterError);
      }})
  }
}
