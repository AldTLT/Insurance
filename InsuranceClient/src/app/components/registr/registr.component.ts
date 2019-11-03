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

  constructor(private authService: AuthService, private router: Router) { }

  userData: User = new User();
  isRegisterError: boolean = false;

  ngOnInit() {
  }

  //Проверка коректности введенных данных
  checkData(){

  }

  userRegistration(user: User){
    this.authService.register(user).subscribe((data: any) => {
      if (data.Succeeded == true)
      this.router.navigate(['/personal']),
      (err: HttpErrorResponse) => {
      this.isRegisterError = true;
      console.log(this.isRegisterError);
      }})
  }
}
