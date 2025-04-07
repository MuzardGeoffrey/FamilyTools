import { BaseModel } from './base-model';
import { User } from './user';
import { AccountEnter } from './account-enter';

export interface AccountPage extends BaseModel {
  name: string;
  lines: AccountEnter[];
  paymentDone: Map<User, boolean>;
  isClosing: boolean;
  date: Date;
}
