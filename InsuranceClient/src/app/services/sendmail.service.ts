import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

//Сервис отправки сообщений на почту.
export class SendmailService {

  constructor(private http: HttpClient) { }

  private rootUrl = "http://localhost:63943";

  //Отправка полиса на почту.
  sendMail(carNumber: string, email: string){    
    let reqHeader = new HttpHeaders({ 'carNumber' : carNumber, 'email' : email});
    return this.http.get(this.rootUrl + '/api/sender/sendmail', { headers: reqHeader } );
  }
}
