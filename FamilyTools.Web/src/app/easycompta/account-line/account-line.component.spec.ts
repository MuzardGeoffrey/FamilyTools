import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountLineComponent } from './account-line.component';

describe('AccountLineComponent', () => {
  let component: AccountLineComponent;
  let fixture: ComponentFixture<AccountLineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountLineComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
