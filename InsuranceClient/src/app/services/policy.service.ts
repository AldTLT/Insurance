import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Car } from '../models/car';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
//Сервис управления полисами.
export class PolicyService {

  constructor(private http: HttpClient) { }

  private rootUrl = "http://localhost:63943";
  httpOptions = {
    headers: new HttpHeaders()
  };

  //Запрос получение полиса по email
  getPolicies(email: string){
    this.httpOptions.headers = new HttpHeaders({'email' : email })
    return this.http.get(this.rootUrl + '/api/policy/policy', this.httpOptions );
  }

  //Запрос расчета стоимости полиса.
  calculatePolicyCost(car: Car, email: string){
    const body: Car = car;
    var reqHeader = new HttpHeaders({'email' : email});
    return this.http.post(this.rootUrl + '/api/policy/policycost', body, { headers: reqHeader } );
  }

  //Запрос регистрации полиса.
  registerPolicy(car: Car, email: string)
  {
    const body: Car = car;
    var reqHeader = new HttpHeaders({'email': email});
    return this.http.post(this.rootUrl + '/api/policy/policyregister', body, { headers: reqHeader });
  }
}
