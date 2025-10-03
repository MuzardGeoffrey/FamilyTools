import { inject, Injectable } from '@angular/core';
import { AccountTag } from '../../models/account-tag';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  http = inject(HttpClient);
  all_tag : AccountTag[] = [];
  all_user : User[]= [];

  constructor(){
    this.getTagListApi();
  }

  public getTagListApi(){
    if (this.http) {
      this.http.get<AccountTag[]>("api/easycompta/AccountTag").subscribe({
        next: result => this.all_tag = result,
        error: error => console.log(error)
      });
    }
  }
}
