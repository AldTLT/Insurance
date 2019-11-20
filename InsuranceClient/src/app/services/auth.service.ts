import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Authorization } from '../models/authorization';
import { User } from '../models/user';
import { ChangePass } from '../models/changepass';

@Injectable({
  providedIn: 'root'
})
//Сервис авторизации.
export class AuthService {

  private rootUrl = "http://localhost:63943";
  httpOptions = {
    headers: new HttpHeaders()
  };

  constructor(private http: HttpClient) { }

  //Запрос получение токена авторизации
  authorization(data: Authorization){
    var bodyData = "grant_type=" + data.grant_type + "&password=" + data.password + "&username=" + data.username;
    var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded', 'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/token', bodyData, { headers: reqHeader });
  }

  //Запрос олучение пользователя по email
  getUser(email: string){
    this.httpOptions.headers = new HttpHeaders({'email' : email })
    return this.http.get(this.rootUrl + '/api/account/user', this.httpOptions );
  }

  //Запрос регистрации пользователя.
  register(user: User){
    const body: User = user;
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/account/register', body, { headers: reqHeader });
  }

  //Запрос смены пароля.
  changePassword(email: string, changePassword: ChangePass){
    const body: ChangePass = changePassword;
    this.httpOptions.headers = new HttpHeaders({'email' : email });
    return this.http.put(this.rootUrl + '/api/account/changepassword', body, this.httpOptions );
  }
}