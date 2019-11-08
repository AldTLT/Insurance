import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

//Класс представляет сервис сохранения данных, и получения сохраненных данных.
export class StoreService {

  //string - ключ, any - значение
  items: [string, any][] = []; 
  value: any;

  constructor() { }

  //Метод добавляет пару ключ-значение в массив.
  //Если пара существует, перезаписывается значение.
  setItem(key: string, value: any){
    this.items.filter(item => {
      if (item != null)
      {
        if (item[0] == key)
        {
          item[1] = value;
          return;
        }
      }
    });

    this.items.push([key, value]);
  }
  
  //Метод возвращает значение по ключу.
  //Если ключа не существует, возвращается null.
  getItem(itemName: string): any{
    this.items.find(item => {
      if (item[0] == itemName)
      {
        this.value = item[1];
      return this.value;
      }

    });
    // return null;
  }
}
