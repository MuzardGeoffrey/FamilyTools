import { BaseModel } from './base-model';

export class AccountTag extends BaseModel {
  name: string;
  color: string;

   constructor(name: string, color: string, id?: number, creationDate?: Date, updateDate?: Date){
      super(id, creationDate, updateDate);
      this.name = name;
      this.color = color;
    }
}
