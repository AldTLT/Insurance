import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pdf } from '../models/pdf';

@Injectable({
  providedIn: 'root'
})
//Сервис работы с файлами.
export class FileService {

  constructor(private http: HttpClient) { }

  private rootUrl = "http://localhost:63943";

  //Запрос возвращает pdf файл и сохраняет на диск. 
  getPdfFile(pdf: Pdf){
    let body = pdf;
    return this.http.post(this.rootUrl + '/api/file/savefile', body, { responseType: 'arraybuffer' });
  }
}
