import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountPage } from '../models/account-page';
import { User } from '../models/user';
import { AccountPageService } from '../core/services/account-page-service';


@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.scss'],
  standalone: false
})
export class AccountPageComponent implements OnInit {
  accountPage: AccountPage | null = null;
  loading = true;
  error = false;
  
  // Pour faciliter l'itération sur Map dans le template
  paymentEntries: {key: boolean, value: User}[] = [];

  constructor(
    private route: ActivatedRoute,
    private accountPageService: AccountPageService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadAccountPage(+id);
    } else {
      this.error = true;
      this.loading = false;
    }
  }

  loadAccountPage(id: number): void {
    this.accountPageService.getAccountPage(id).subscribe({
      next: (data) => {
        this.accountPage = data;
        
        // Convertir Map en array pour faciliter l'itération dans le template
        if (this.accountPage.paymentDone) {
          this.paymentEntries = Array.from(this.accountPage.paymentDone.entries())
            .map(([key, value]) => ({ key, value }));
        }
        
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading account page:', err);
        this.error = true;
        this.loading = false;
      }
    });
  }

  calculateTotal(): number {
    if (!this.accountPage?.lines) return 0;
    return this.accountPage.lines.reduce((sum, line) => sum + line.value, 0);
  }

  getPaymentStatus(paid: boolean): string {
    return paid ? 'Payé' : 'Non payé';
  }

  formatDate(date: Date): string {
    return new Date(date).toLocaleDateString();
  }
}
