// account-page.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { AccountPage } from '../../models/account-page';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountPageService {
  private apiUrl = `${environment.apiUrl}/accountpages`;

  constructor(private http: HttpClient) {}

  getAccountPages(): Observable<AccountPage[]> {
    return this.http.get<AccountPage[]>(this.apiUrl)
      .pipe(
        map(pages => pages.map(page => this.transformDates(page)))
      );
  }

  getAccountPage(id: number): Observable<AccountPage> {
    return this.http.get<AccountPage>(`${this.apiUrl}/${id}`)
      .pipe(
        map(page => {
          // Convertir dictionary en Map
          const paymentDoneMap = new Map<boolean, any>();
          if (page.paymentDone) {
            Object.entries(page.paymentDone).forEach(([key, value]) => {
              paymentDoneMap.set(key === 'true', value);
            });
          }
          page.paymentDone = paymentDoneMap;
          
          return this.transformDates(page);
        })
      );
  }

  createAccountPage(accountPage: AccountPage): Observable<AccountPage> {
    return this.http.post<AccountPage>(this.apiUrl, accountPage);
  }

  updateAccountPage(accountPage: AccountPage): Observable<AccountPage> {
    return this.http.put<AccountPage>(`${this.apiUrl}/${accountPage.id}`, accountPage);
  }

  deleteAccountPage(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  // Transformation des dates depuis les chaînes JSON
  private transformDates(page: AccountPage): AccountPage {
    if (page.date) {
      page.date = new Date(page.date);
    }
    if (page.creationDate) {
      page.creationDate = new Date(page.creationDate);
    }
    if (page.updateDate) {
      page.updateDate = new Date(page.updateDate);
    }
    return page;
  }
}
