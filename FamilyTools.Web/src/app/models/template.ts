import { BaseModel } from './base-model';
import { AccountLine } from './account-line';

export class Template extends BaseModel {
  name: string;
  lines: AccountLine[];
  lifeTime: Date;

  constructor(name: string, lines: AccountLine[], lifeTime: Date, id?: number, creationDate?: Date, updateDate?: Date) {
    super(id, creationDate, updateDate);
    this.name = name;
    this.lines = lines;
    this.lifeTime = lifeTime;
  }
}
