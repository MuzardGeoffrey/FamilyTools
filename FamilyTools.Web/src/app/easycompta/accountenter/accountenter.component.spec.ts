import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountenterComponent } from './accountenter.component';

describe('AccountenterComponent', () => {
  let component: AccountenterComponent;
  let fixture: ComponentFixture<AccountenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountenterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
