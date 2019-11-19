import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/services/policy.service';
import { EmailValidator } from '@angular/forms';
import { StoreService } from 'src/app/services/store.service';
import { JsonpInterceptor } from '@angular/common/http';
import { Policy } from 'src/app/models/policy';
import { Car } from 'src/app/models/car';

@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.scss']
})
export class PoliciesComponent implements OnInit {

  constructor(private policyService: PolicyService, private storeService: StoreService) { }

  policies: Policy[] = [];
  policy: Policy;
  policyNumber: number;

  ngOnInit() {
    let email = this.storeService.getItem('email');
    this.policyService.getPolicies(email).subscribe((data: any) => {
      this.policyNumber = 0;
      
      data.forEach(p => {
        this.policyNumber ++;

        let newPolicy = new Policy();
        newPolicy.PolicyId = p.PolicyId;
        newPolicy.Cost = p._cost;
        newPolicy.PolicyDate = p.PolicyDate;
        newPolicy.UsersEmail = p.UsersEmail;
        newPolicy.Car = new Car();
        newPolicy.Car.CarCost = p.Car._cost;
        newPolicy.Car.CarModel = p.Car.Model;
        newPolicy.Car.CarNumber = p.Car.CarNumber;
        newPolicy.Car.EnginePower = p.Car._enginePower;
        newPolicy.Car.ManufacturedYear = p.Car._manufacturedYear;

        this.policies.push(newPolicy);
      });
    })
  }
}
