import { Role } from './Role';

export class User{
    EMail: string;
    Name: string;
    BirthDate: Date;
    DriverLicenseDate: Date;
    Password: string;
    Role?: Role[];
}