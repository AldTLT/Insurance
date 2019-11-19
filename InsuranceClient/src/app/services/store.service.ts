import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

//Сервис сохранения и получения сохраненных данных.
export class StoreService {

  //string - ключ, any - значение
  items: [string, any][] = [];

  constructor() { }

  //Метод добавляет пару ключ-значение в массив.
  //Если пара существует, перезаписывается значение.
  setItem(key: string, value: any){
    // debugger;
    let flag = this.items.filter(item => {
      if (item != null)
      {
        if (item[0] == key)
        {
          item[1] = value;
          return item;
        }        
      }
    });

    if (flag.length == 0)
    {
      this.items.push([key, value]);
    }
  }
  
  //Метод возвращает значение по ключу.
  //Если ключа не существует, возвращается null.
  getItem(itemName: string): any{
    let item = this.items.find(data => {
      if (data[0] == itemName)
      {
        return data;
      }
    });

    return item == null ? null : item[1];
  }

  //Метод очищает все хранилище
  clear(){
    this.items = [];
  }
}
