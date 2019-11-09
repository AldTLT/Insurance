import { Car } from './car';
import { Ratio } from './ratio';

export class Policy{
    PolicyId: string;
    Cost: number;
    UsersEmail: string;
    PolicyDate: Date;
    Car?: Car;
    Ratio?: Ratio;
}