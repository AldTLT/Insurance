import { Injectable } from '@angular/core';
import { CarsList } from '../models/carslist';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor() { }

  lada: string[] = ["GRANTA","VESTA","XRAY","LARGUS","4x4"]
  kia: string[] = ["PICANTO", "RIO", "CEED", "CERATO", "OPTIMA", "STINGER", "SOUL", "SPORTAGE", "SORENTO", "MOHAVE"]
  toyota: string[] = ["COROLLA", "CAMRY", "HIGHLANDER", "HYLUX", "LAND CRUISER"]
  ford: string[] = ["FIESTA", "FOCUS", "MONDEO", "KUGA", "EXPLORER"]

  result: string[];

  cars: CarsList[] = [
    { Automaker: "LADA", Models: this.lada },
    { Automaker: "KIA", Models: this.kia },
    { Automaker: "TOYOTA", Models: this.toyota },
    { Automaker: "FORD", Models: this.ford }
  ]

  //Метод возвращает список моделей производителя.
  getCarModel(automaker: string): any{
    this.cars.forEach(car => {
      if (car.Automaker == automaker)
      {
        this.result = car.Models;
        return;
      }
    });
    return this.result;
  }
}
