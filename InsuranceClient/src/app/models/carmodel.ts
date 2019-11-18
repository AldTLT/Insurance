//Класс представляет поля с данными названия автомобиля.
export class CarModel{
    automaker: string;
    model: string;

    //Метод возвращает название автомобиля, составленое из фирмы и модели, разделенных пробелом.
    getCarName(): string{
        return this.automaker + ' ' + this.model;
    }
}