import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';
import { HttpErrorResponse } from '@angular/common/http';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss']
})
export class DataComponent implements OnInit {

  constructor(private authService: AuthService, private storeService: StoreService) { }

  email: string;
  user: User = new User;

  ngOnInit() {
    this.email = this.storeService.getItem('email');
    this.authService.getUser(this.email).subscribe((data: any) => {
      this.user.EMail = data.EMail;
      this.user.Name = data.Name;
      this.user.BirthDate = data._birthDate;
      this.user.DriverLicenseDate = data._driverLicenseDate;
    },    
    (err: HttpErrorResponse) => {
      //Обработать ошибку
    });
  }
  

}
