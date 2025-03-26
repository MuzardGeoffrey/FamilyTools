import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountLine } from './models/account-line';
import { AccountPage } from './models/account-page';
import { catchError, map } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public accountpage: AccountPage = {} as AccountPage;
  ;
  ;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAccountPage();
  }

  getAccountPage() {
    this.http.get<AccountPage>('/easycompta')
      .pipe(
        map(
          (result) => {
            this.accountpage = result;
          }),
      );
  }

  createNewLine(accountLine : AccountLine) {
    this.http.post<AccountLine>('/easycompta/line', accountLine).subscribe(
      (result) => {
        if (result != null) {
          this.accountpage.lines.push(result);
        }
      },
      (error) => {
        console.error(error);
      }
    )
  }

  title = 'easycompta.client';
}
