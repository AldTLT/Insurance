import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pdf } from '../models/pdf';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  private rootUrl = "http://localhost:63943";

  constructor(private http: HttpClient) { }

  // getPdfFile(carNumber: string, email: string){
  //   let reqHeader = new HttpHeaders({ 'carNumber' : carNumber, 'email' : email});
  //   return this.http.get(this.rootUrl + '/api/file/savefile', { responseType: 'arraybuffer', headers: reqHeader });
  // }

  getPdfFile(pdf: Pdf){

    let body = pdf;
    return this.http.post(this.rootUrl + '/api/file/savefile', body, { responseType: 'arraybuffer' });
  }
}
