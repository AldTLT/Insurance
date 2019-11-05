import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/cardata';

@Component({
  selector: 'app-buypolicy',
  templateUrl: './buypolicy.component.html',
  styleUrls: ['./buypolicy.component.scss']
})
export class BuypolicyComponent implements OnInit {

  constructor() { }

  car: Car = new Car();

  ngOnInit() {
  }

  calculatePolicy(car: Car)
  {
    
  }

}
