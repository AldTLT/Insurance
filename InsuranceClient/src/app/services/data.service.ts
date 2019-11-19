import { Injectable } from '@angular/core';
import {BehaviorSubject} from  'rxjs' ;

@Injectable({
  providedIn: 'root'
})
//Сервис обмена данными между компонентами.
export class DataService {

  private messageSource = new BehaviorSubject(false);
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  //Метод меняет статус сообщения.
  changeLogStatus(status: boolean) {
    this.messageSource.next(status)
  }
}
