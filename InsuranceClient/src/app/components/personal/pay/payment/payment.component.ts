import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';
import { SendmailService } from 'src/app/services/sendmail.service';
import { FileService } from 'src/app/services/file.service';
import { saveAs } from 'file-saver';
import * as jsPDF from 'jspdf';
import { Pdf } from 'src/app/models/pdf';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  constructor(
    private router: Router, 
    private storeService: StoreService, 
    private sendmailService: SendmailService,
    private fileService: FileService
    ) { }

    email: string; 
    carNumber: string;
    // file: Uint8Array;
    pdfFile: jsPDF = new jsPDF();
    pdf: Pdf = new Pdf();

  ngOnInit() {
    this.email = this.storeService.getItem('email');
    this.carNumber = this.storeService.getItem('carNumber');
    this.pdf.carNumber = this.carNumber;
    this.pdf.email = this.email;
  }

    //Метод отправки полиса на почту.
    sendPolicy(){
      this.sendmailService.sendMail(this.carNumber, this.email).subscribe((data) => {
        console.log(data);
      });
    }

    //Метод сохранения полиса.
    savePolicy(){
      this.fileService.getPdfFile(this.pdf).subscribe((data) => {
        let blob = new Blob([data], { type: 'application/pdf'});
        console.log(data.byteLength);
        saveAs(blob, 'test.pdf');
        console.log(data);
      })
    }

}
