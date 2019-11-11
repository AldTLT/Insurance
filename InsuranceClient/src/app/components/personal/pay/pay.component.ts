import { Component, OnInit } from '@angular/core';
import { StoreService } from 'src/app/services/store.service';
import { Router } from '@angular/router';
import { SendmailService } from 'src/app/services/sendmail.service';
import { PolicyService } from 'src/app/services/policy.service';
import { dashCaseToCamelCase } from '@angular/compiler/src/util';

@Component({
  selector: 'app-pay',
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.scss']
})
export class PayComponent implements OnInit {

  constructor(
    private router: Router, 
    private storeService: StoreService, 
    private sendmailService: SendmailService,
    private policyService: PolicyService
    ) { }

  toPayment: boolean;
  policyCost: any;
  isPolicyRegistered: boolean;

  ngOnInit() {
    this.toPayment = false;
    this.policyCost = this.storeService.getItem('policyCost');
  }

  //Метод отправки полиса на почту
  payPolicy(){
    this.isPolicyRegistered = this.registerPolicy();
    if (!this.isPolicyRegistered)
    {
      //Обработать ошибку регистрации
      return;
    }

    this.toPayment = true;
    const email = this.storeService.getItem('email');
    const carNumber = this.storeService.getItem('carNumber');
    this.sendmailService.sendMail(carNumber, email).subscribe((data) => {
      console.log(data);
    });
    this.router.navigate(['/personal/pay/payment']);
  }

  //Регистрация нового полиса.
  registerPolicy(): any{
    let car = this.storeService.getItem('car');
    let email = this.storeService.getItem('email');

    return this.policyService.registerPolicy(car, email).subscribe((data) => {
      console.log(data);
      return data;
    });
  }
}
