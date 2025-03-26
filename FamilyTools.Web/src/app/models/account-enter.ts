import { BaseModel } from './base-model';
import { AccountLine } from './account-line';
import { AccountTag } from './account-tag';

export interface AccountEnter extends BaseModel {
  lines: AccountLine[];
  tag: AccountTag;
  name: string;
  totalValue: number;
  lifeTime: Date;
}
