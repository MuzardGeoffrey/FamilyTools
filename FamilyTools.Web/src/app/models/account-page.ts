import { BaseModel } from './base-model';
import { AccountLine } from './account-line';
import { User } from './user';

export interface AccountPage extends BaseModel {
  name: string;
  lines: AccountLine[];
  paymentDone: Map<boolean, User>;
  isClosing: boolean;
  date: Date;
}
