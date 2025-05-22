import { BaseModel } from './base-model';
import { AccountLine } from './account-line';
import { AccountTag } from './account-tag';

export class AccountEnter extends BaseModel {
  lines: AccountLine[];
  tag: AccountTag;
  name: string;
  totalValue: number;
  date: Date;

  constructor(lines: AccountLine[], tag: AccountTag, name: string, totalValue: number, date: Date, id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.lines = lines;
    this.tag = tag;
    this.name = name;
    this.totalValue = totalValue;
    this.date = date;
  }
}
