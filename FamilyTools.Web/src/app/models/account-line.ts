import { BaseModel } from './base-model';
import { User } from './user';

export class AccountLine extends BaseModel {
  userLink: User;
  value: number;

  constructor(userLink: User, value: number, id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.userLink = userLink;
    this.value = value;
  }
}
