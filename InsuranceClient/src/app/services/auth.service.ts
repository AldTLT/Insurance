import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Authorization } from '../models/authorizationData';
import { User } from '../models/userdata';
// import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private registerUrl = "http://localhost:63943/api/account/register";
  private loginUrl = "http://localhost:63943/api/account/login"
  private rootUrl = "http://localhost:63943"

  httpOptions = {
    headers: new HttpHeaders()
  };

  // body: any = "grant_type=password&username=test@mail.ru&password=qwerty123";

  constructor(private http: HttpClient) { }

  //Получение токена авторизации
  authorization(data: Authorization){
    var bodyData = "grant_type=" + data.grant_type + "&password=" + data.password + "&username=" + data.username;
    var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded', 'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/token', bodyData, { headers: reqHeader });
  }

  //Получение пользователя по email
  getUser(email: string){
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    this.httpOptions.headers = new HttpHeaders({'email' : email })
    return this.http.get(this.rootUrl + '/api/account/user', this.httpOptions );
    // this.httpOptions.headers = new HttpHeaders({'email' : email, 'Authorization' : token})
    // return this.http.get('http://localhost:63943/api/account/user', this.httpOptions);
  }

  register(user: User){
    const body: User = user;
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/account/register', body, { headers: reqHeader });
  }
}
