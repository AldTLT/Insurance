import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { StoreService } from './services/store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']

})
export class AppComponent implements OnInit{

  constructor(private router: Router, private storeService: StoreService){}

  ngOnInit(){
  }

  title = 'InsuranceClient';
  @Output() isLogged: boolean;

  logIn(){
    this.router.navigate(['/authorization']);
  }

  logOut(){
    this.storeService.clear();
    localStorage.clear();
    this.router.navigate(['/authorization']);
    this.isLogged = false;
  }
}
