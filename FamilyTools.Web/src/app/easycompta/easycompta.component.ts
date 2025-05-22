import { Component, Injectable } from '@angular/core';
import { AccountPage } from '../models/account-page';
import { HttpClient } from '@angular/common/http';

@Injectable()
@Component({
  selector: 'app-easycompta',
  standalone: true,
  templateUrl: './easycompta.component.html',
  styleUrl: './easycompta.component.css'
})
export class EasycomptaComponent {

  title = 'EasyCompta';
  pages: {[id: number] : AccountPage} = [];
  current_page: AccountPage | undefined;

  private _http: HttpClient | undefined;

  constructor(http:HttpClient) {
    this._http = http;
    this.call_new_page();
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

  private call_new_page() {
    if(this._http)
      {
        this._http.get<AccountPage>('api/easycompta/AccountPage').subscribe({
          next: result => this.current_page = result,
          error: console.error
        });
  
        if (this.current_page && this.current_page.id) {
          this.pages[this.current_page.id] = this.current_page;
        }
      }
  }
}
