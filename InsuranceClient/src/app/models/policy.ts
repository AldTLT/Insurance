import { Car } from './car';
import { Ratio } from './ratio';

export class Policy{
    Cost: number;
    UsersEmail: string;
    PolicyDate: Date;
    Car?: Car;
    Ratio?: Ratio;
}