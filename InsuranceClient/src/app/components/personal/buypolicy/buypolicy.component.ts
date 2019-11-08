import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { PolicyService } from 'src/app/services/policy.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-buypolicy',
  templateUrl: './buypolicy.component.html',
  styleUrls: ['./buypolicy.component.scss']
})
export class BuypolicyComponent implements OnInit {

  constructor(private router: Router, private policyService: PolicyService) { 
    this.car.CarNumber = "QWE999163RU";
    this.car.CarModel = "Ford";
    this.car.ManufacturedYear = 2018;
    this.car.EnginePower = 104;
    this.car.CarCost = 850000;
  }

  car: Car = new Car();
  email: string;

  ngOnInit() {
  }

  calculatePolicy(car: Car)
  {
    this.email = localStorage.getItem('email');
    console.log(this.email);
    this.policyService.calculatePolicyCost(car, this.email).subscribe((data: any) => {
      localStorage.setItem('policyCost', data);
      this.router.navigate(['personal/pay']);
    })
  }

}
