import { Component, OnInit, Input } from '@angular/core';
import { Policy } from 'src/app/models/policy';
import { SendmailService } from 'src/app/services/sendmail.service';
import { StoreService } from 'src/app/services/store.service';
import { EmailValidator } from '@angular/forms';
import { FileService } from 'src/app/services/file.service';
import { Pdf } from 'src/app/models/pdf';

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
    this.pdf.email = this.storeService.getItem('email');
    this.pdf.carNumber = this.policy.Car.CarNumber;
  }

  email: string;
  carNumber: string;
  endPolicyDate: Date = new Date();
  pdf: Pdf = new Pdf();

    @Input() policy: Policy;

    sendPdf(){
      this.sendmailService.sendMail(this.carNumber, this.email).subscribe((data) => {
      });
    }

    savePdf(){
      this.fileService.getPdfFile(this.pdf).subscribe((data) => {
        let blob = new Blob([data], { type: 'application/pdf'});
        const fileName = this.pdf.carNumber + '.pdf';
        saveAs(blob, fileName);
      });
    }
}
