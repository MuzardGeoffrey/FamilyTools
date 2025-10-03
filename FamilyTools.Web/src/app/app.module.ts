import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { UserService } from './service/accountService/user.service';


@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
],
  providers: [UserService],
  bootstrap: []
})
export class AppModule { }
