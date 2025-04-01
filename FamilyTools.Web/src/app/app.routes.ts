import { Routes } from '@angular/router';
import { EasycomptaComponent } from './easycompta/easycompta.component';
import { UserComponent } from './user/user.component';

export const routes: Routes = [
    {path: 'easycompta', component: EasycomptaComponent},
    {path: 'user', component: UserComponent}
];
