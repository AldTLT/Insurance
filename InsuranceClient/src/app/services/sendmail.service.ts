import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SendmailService {

  private rootUrl = "http://localhost:63943";

  constructor(private http: HttpClient) { }

    //Отправка сообщения на почту.
    sendMail(carNumber: string, email: string){      
      let reqHeader = new HttpHeaders({ 'carNumber' : carNumber, 'email' : email});
      return this.http.get(this.rootUrl + '/api/sender/sendmail', { headers: reqHeader } );
    }
}
