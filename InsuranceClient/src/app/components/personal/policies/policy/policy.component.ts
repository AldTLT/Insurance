import { Component, OnInit, Input } from '@angular/core';
import { Policy } from 'src/app/models/policy';
import { SendmailService } from 'src/app/services/sendmail.service';
import { StoreService } from 'src/app/services/store.service';
import { EmailValidator } from '@angular/forms';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent implements OnInit{

  constructor(private storeService: StoreService, private sendmailService: SendmailService){}

  ngOnInit(){
  }

  endPolicyDate: Date = new Date();

    @Input() policy: Policy;

    sendPdf(){
      const email = this.storeService.getItem('email');
      const carNumber = this.policy.Car.CarNumber;
      this.sendmailService.sendMail(carNumber, email).subscribe((data) => {
        // debugger;
      });
    }
}
