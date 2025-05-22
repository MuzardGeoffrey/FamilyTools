import { BaseModel } from './base-model';
import { User } from './user';

export class AccountLine extends BaseModel {
  name: string;
  userLink: User;
  value: number;

  constructor(name: string, userLink: User, value: number, id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.name = name;
    this.userLink = userLink;
    this.value = value;
  }
}
