import { BaseModel } from './base-model';
import { User } from './user';
import { AccountEnter } from './account-enter';

export class AccountPage extends BaseModel {
  name: string;
  enters: AccountEnter[];
  paymentDones: Map<User, boolean>;
  isClosing: boolean;
  date: Date;

  constructor(  name: string, enters: AccountEnter[], paymentDones: Map<User, boolean>, isClosing: boolean, date: Date, id?: number, creationDate?: Date, updateDate?: Date){
    super(id, creationDate, updateDate);
    this.name = name;
    this.enters = enters;
    this.paymentDones = paymentDones;
    this.isClosing = isClosing;
    this.date = date;
  }

    getUsers(): User[] {
      return Array.from(this.paymentDones.keys());
    }

    getTotalForUser(id: number){
      this.enters.map(enters => enters.lines.filter(lines => lines.userLink.id == id).reduce((acc, lines) => acc + lines.value, 0))
    }

    getTotal(){
      this.enters.reduce((acc, enter) => acc + enter.totalValue, 0)
    }
}
