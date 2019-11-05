import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Car } from '../models/cardata';

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
      this.httpOptions.headers = new HttpHeaders({'email' : email })
      return this.http.get(this.rootUrl + '/api/policy/policy', this.httpOptions );
    }

    // calculatePolicyCost(car: Car){
    //   const body: Car = car;
    //   const email = localStorage.getItem('email');
    //   var reqHeader = new HttpHeaders({'No-Auth':'True', 'email' : email});
    //   return this.http.get(this.rootUrl + '/api/policy/policycost', {headers: reqHeader, observe: body } );
    // }
}
