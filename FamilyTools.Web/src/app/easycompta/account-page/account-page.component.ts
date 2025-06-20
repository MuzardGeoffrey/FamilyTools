import { Component, inject, OnInit } from '@angular/core';
import { AccountPage } from '../../models/account-page';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AccountTag } from '../../models/account-tag';

@Component({
  selector: 'app-accountpage',
  imports: [RouterLink, DatePipe],
  templateUrl: './account-page.component.html',
  styleUrl: './account-page.component.css'
})
export class AccountPageComponent implements OnInit{
pages: {[id: number] : AccountPage} = [];
  current_page: AccountPage | undefined;
  month_list: Date[] = [];
  current_tags: AccountTag[] = [];

  private _http = inject(HttpClient);
  private router = inject(Router);

  ngOnInit(): void {
    this.call_new_page();
    this.get_all_month();
  }
  
  public async changePages(id:number) {
    if (this.pages[id] == undefined) {
      this.call_new_page();
    }
    else
    {
      this.current_page = this.pages[id];
    }
  }

  private get_all_month() {
    if (this._http) {
      this._http.get<Date[]>('api/easycompta/AccountPage/getallmonth').subscribe({
        next: result => this.month_list = result,
        error: console.error
      });
    }  
  }

  private call_new_page() {
    if(this._http)
      {
        this._http.get<AccountPage>('api/easycompta/AccountPage').subscribe({
          next: result => {
            this.current_page = result;
          },
          error: console.error
        });
  
        if (this.current_page && this.current_page.id) {
          this.pages[this.current_page.id] = this.current_page;
        }
      }
  }

  addAccountEnter(){
    this.router.navigate(["/accountenter"]);
  }
}
