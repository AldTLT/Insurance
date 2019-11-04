import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

  private rootUrl = "http://localhost:63943";
  httpOptions = {
    headers: new HttpHeaders()
  };

  constructor(private http: HttpClient) { }

    //Получение полиса по email
    getPolicies(email: string){
      var reqHeader = new HttpHeaders({'No-Auth':'True'});
      this.httpOptions.headers = new HttpHeaders({'email' : email })
      return this.http.get(this.rootUrl + '/api/policy/policy', this.httpOptions );
    }
}
