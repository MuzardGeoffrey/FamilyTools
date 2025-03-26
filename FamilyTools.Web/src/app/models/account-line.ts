import { BaseModel } from './base-model';
import { User } from './user';

export interface AccountLine extends BaseModel {
  name: string;
  userLink: User;
  value: number;
}
