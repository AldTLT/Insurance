import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { PolicyService } from 'src/app/services/policy.service';
import { Router } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';
import { CarModel } from 'src/app/models/carmodel';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-buypolicy',
  templateUrl: './buypolicy.component.html',
  styleUrls: ['./buypolicy.component.scss']
})
export class BuypolicyComponent implements OnInit {

  constructor(
    private router: Router, 
    private policyService: PolicyService, 
    private storeService: StoreService,
    private carService: CarService
    ) { 

    // this.car.CarNumber = "QWE999163RU";
    // this.carModel.automaker = "Ford";
    // this.carModel.model = "Focus";
    // this.car.ManufacturedYear = 2018;
    // this.car.EnginePower = 104;
    // this.car.CarCost = 850000;
  }

  car: Car = new Car();
  carModel: CarModel = new CarModel();
  email: string;
  isDataCorrect: boolean;
  carsAutomakerMenu: string[];
  carModelsMenu: string[];

  isCarNumberCorrect: boolean;
  isCarAutomakerCorrect: boolean;
  isCarModelCorrect: boolean;
  isCarManufacturingYearCorrect: boolean;
  isCarEnginePowerCorrect: boolean;
  isCarCostCorrect:boolean;

  carNumberColor: string;
  carAutomakerColor: string;
  carModelColor: string;
  carManufacturingYearColor: string;
  carEnginePowerColor: string;
  carCostColor: string;

  ngOnInit() {
    this.isDataCorrect = true;
    this.carsAutomakerMenu = ["LADA", "KIA" ];
  }

  //Метод возвращает список моделей производителя.
  getCar(automaker: string){
    this.carModelsMenu = this.carService.getCarModel(automaker);
  }

  //Метод возвращает true если строка пустая, иначе - false.
  isEmpty(data: string): boolean {
    return !data || data.length === 0;
  }
  
  //Метод возвращает true если строка пустая, или длинна строки не находится между minLength и maxLength.
  isShort(data: string, minLength: number, maxLength: number): boolean{
    return this.isEmpty(data) ? true : !(data.length >= minLength && data.length <= maxLength);
  }

  //Метод проверки номера автомобиля.
  checkCarNumber(){
    this.isCarNumberCorrect = !this.isShort(this.car.CarNumber, 3, 15);
    this.carNumberColor = this.isCarNumberCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }

    //Инициализация цвета фона поля.
  initializeCarNumber(){
    this.carNumberColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки марки автомобиля.
  checkCarAutomaker(){
    this.isCarAutomakerCorrect = !this.isShort(this.carModel.automaker, 2, 30);
    this.carAutomakerColor = this.isCarAutomakerCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }
  
  //Инициализация цвета фона поля.
  initializeCarAutomaker(){
    this.carAutomakerColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки модели автомобиля.
  checkCarModel(){
    this.isCarModelCorrect = !this.isShort(this.carModel.model, 2, 30);
    this.carModelColor = this.isCarModelCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }
    
  //Инициализация цвета фона поля.
  initializeCarModel(){
    this.carModelColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки года выпуска автомобиля.
  checkCarManufacturingYear(){
    let thisYear = new Date().getFullYear();
    //Минимальный год выпуска автомобиля.
    const minYear = 1920;
    this.isCarManufacturingYearCorrect = this.car.ManufacturedYear >= minYear && this.car.ManufacturedYear <= thisYear;
    this.carManufacturingYearColor = this.isCarManufacturingYearCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }
    
  //Инициализация цвета фона поля.
  initializeCarManufacturingYear(){
    this.carManufacturingYearColor = 'rgb(240, 240, 240)';
  }

  //Метод проверки мощности двигателя автомобиля.
  checkCarEnginePower(){
    //Максимальная мощность автомобиля.
    const maxPower = 300;
    //Минимальная мощность автомобиля.
    const minPower = 2;
    this.isCarEnginePowerCorrect = this.car.EnginePower >= minPower && this.car.EnginePower <= maxPower;
    this.carEnginePowerColor = this.isCarEnginePowerCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }
    
  //Инициализация цвета фона поля.
  initializeCarEnginePower(){
    this.carEnginePowerColor = 'rgb(240, 240, 240)';
  }

   //Метод проверки стоимости автомобиля.
   checkCarCost(){
    //Максимальная стоимость автомобиля.
    const maxCost = 20000000;
    //Минимальная стоимость автомобиля.
    const minCost = 5000;
    this.isCarCostCorrect = this.car.CarCost >= minCost && this.car.CarCost <= maxCost;
    this.carCostColor = this.isCarCostCorrect ? 'rgb(240, 240, 240)' : 'rgb(216, 149, 149)';
  }
    
  //Инициализация цвета фона поля.
  initializeCarCost(){
    this.carCostColor = 'rgb(240, 240, 240)';
  } 

  calculatePolicy(car: Car)
  {
    console.log(this.carModel.automaker);
    console.log(this.carModel.model);

    this.checkCarNumber();
    this.checkCarManufacturingYear();
    this.checkCarEnginePower();
    this.checkCarCost();
    
    if (
      !this.isCarNumberCorrect
      || !this.isCarManufacturingYearCorrect
      || !this.isCarEnginePowerCorrect
      || !this.isCarCostCorrect
    )
    {
      this.isDataCorrect = false;
    }
    else
    {
      this.isDataCorrect = true;
      car.CarModel = this.carModel.getCarName();

      this.storeService.setItem('car', car);
      this.email = this.storeService.getItem('email');
      this.policyService.calculatePolicyCost(car, this.email).subscribe((data: any) => {
        this.storeService.setItem('policyCost', data);
        this.storeService.setItem('carNumber', car.CarNumber);
        this.router.navigate(['personal/pay']);
      })
    }
  }
}
