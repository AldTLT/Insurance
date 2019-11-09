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

    this.userData.EMail = "test2@mail.ru";
    this.clientName.name = "Vasiliy";
    this.clientName.surname = "Pupkin";
    this.clientName.patronymic = "Ivanovich";
    this.userData.BirthDate = new Date(1980, 1, 1, 0, 0, 0, 0);
    this.userData.DriverLicenseDate = new Date(2010, 2, 2, 0, 0, 0, 0);
    this.userData.Password = "qwerty123456";
  }

  userData: User = new User();
  isRegisterError: boolean = false;
  registerResult: boolean = false;
  clientName: ClientName = new ClientName(); 

  ngOnInit() {
  }

  //Проверка коректности введенных данных
  checkData(){

  }

  userRegistration(){
    this.userData.Name = this.clientName.getFullName();
    this.authService.register(this.userData).subscribe((data: any) => {
      this.registerResult = data;
      if (data == true)
      this.router.navigate(['/registration/success']),

      (err: HttpErrorResponse) => {
      this.isRegisterError = true;
      }})
  }
}
