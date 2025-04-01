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
  Pages: AccountPage[] = [];

  constructor(private http:HttpClient) {
    http.get<AccountPage[]>('api/easycompta/AccountPage').subscribe({
      next: result => this.Pages = result,
      error: console.error
    });
  }
}
