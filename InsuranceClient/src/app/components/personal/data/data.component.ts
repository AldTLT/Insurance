import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/userdata';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss']
})
export class DataComponent implements OnInit {

  constructor(private authService: AuthService) { }

  email: string;
  user: any;

  ngOnInit() {
    this.email = localStorage.getItem('email');
    this.authService.getUser(this.email).subscribe((data: any) => {
      this.user = data;
      console.log(this.user);
    },    
    (err: HttpErrorResponse) => {
      //Обработать ошибку
    });
  }
  

}
