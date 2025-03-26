import { BaseModel } from './base-model';
import { AccountLine } from './account-line';

export interface Template extends BaseModel {
  name: string;
  lines: AccountLine[];
  lifeTime: Date; // Note: Angular/TypeScript n'a pas d'équivalent direct à DateOnly, on utilise Date
}
