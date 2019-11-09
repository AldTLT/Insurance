//Класс представляет поля с данными полного имени клиента.
export class ClientName{
    name: string;
    surname: string;
    patronymic: string;

    //Метод возвращает полное имя, составленное из данных полей, разделенных символом '_'
    getFullName(): string{
        return this.name + ' ' + this.surname + ' ' + this.patronymic;
    }
}