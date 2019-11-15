import { Component, OnInit, Output } from '@angular/core';
import { StoreService } from 'src/app/services/store.service';
import { Router } from '@angular/router';
import { PolicyService } from 'src/app/services/policy.service';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.scss']
})
export class PayComponent implements OnInit {

  constructor(
    private router: Router, 
    private storeService: StoreService, 
    private policyService: PolicyService
    ) { }

  toPayment: boolean;
  policyCost: any;
  isPolicyRegistered: boolean;
  @Output() policyNumber: string;

  ngOnInit() {
    this.toPayment = false;
    this.policyCost = this.storeService.getItem('policyCost');
  }

  //Регистрация нового полиса.
  registerPolicy(): any{
    let car = this.storeService.getItem('car');
    let email = this.storeService.getItem('email');

    this.policyService.registerPolicy(car, email).subscribe((data: any) => {
    if (data != null)
    {
      this.policyNumber = data;
      this.toPayment = true;
      console.log(this.policyNumber);
    }
    else
    {
      //Сообщение об ошибке.
      return;
    }

    this.router.navigate(['/personal/pay/payment']);
    });
  }
}
