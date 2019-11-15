import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Car } from '../models/car';
import { User } from '../models/user';

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

    calculatePolicyCost(car: Car, email: string){
      const body: Car = car;
      var reqHeader = new HttpHeaders({'email' : email});
      return this.http.post(this.rootUrl + '/api/policy/policycost', body, { headers: reqHeader } );
    }

    registerPolicy(car: Car, email: string)
    {
      const body: Car = car;
      var reqHeader = new HttpHeaders({'email': email});
      return this.http.post(this.rootUrl + '/api/policy/policyregister', body, { headers: reqHeader });
    }
}
