import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountTagComponent } from './account-tag.component';

describe('Account-tag-Component', () => {
  let component: AccountTagComponent;
  let fixture: ComponentFixture<AccountTagComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountTagComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountTagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
