import { Component, OnInit, Input } from '@angular/core';
import { Policy } from 'src/app/models/policy';
import { SendmailService } from 'src/app/services/sendmail.service';
import { StoreService } from 'src/app/services/store.service';
import { EmailValidator } from '@angular/forms';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.scss']
})
export class PolicyComponent implements OnInit{

  constructor(
    private storeService: StoreService, 
    private sendmailService: SendmailService,
    private fileService: FileService
    ){}

  ngOnInit(){
    this.email = this.storeService.getItem('email');
    this.carNumber = this.policy.Car.CarNumber;
  }

  email: string;
  carNumber: string;
  endPolicyDate: Date = new Date();

    @Input() policy: Policy;

    sendPdf(){
      this.sendmailService.sendMail(this.carNumber, this.email).subscribe((data) => {
      });
    }

    savePdf(){
      this.fileService.getPdfFile(this.carNumber, this.email).subscribe((data) => {
        console.log(data);
      });
    }
}
