import { BaseModel } from './base-model';
import { AccountLine } from './account-line';
import { AccountTag } from './account-tag';

export class AccountEnter extends BaseModel {
  lines: AccountLine[];
  tag: AccountTag;
  name: string;
  totalValue: number;
  date: Date;

  constructor(name: string, totalValue: number, tag: AccountTag, date: Date, lines: AccountLine[], id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.lines = lines;
    this.tag = tag;
    this.name = name;
    this.totalValue = totalValue;
    this.date = date;
  }

    getTotal() : number{
      return this.lines.reduce((acc, line) => acc + line.value, 0)
    }
}
