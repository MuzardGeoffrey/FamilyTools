import { BaseModel } from './base-model';

export class User extends BaseModel{
  firstName: string;
  lastName: string;
  userName: string;

  constructor(firstName: string, lastName: string, userName: string, id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.firstName = firstName;
    this.lastName = lastName;
    this.userName = userName;
  }

}
