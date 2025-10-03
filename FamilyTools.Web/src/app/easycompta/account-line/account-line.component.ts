import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../service/accountService/account.service';
import { AccountEnterComponent } from '../account-enter/account-enter.component';
import { AccountLine } from '../../models/account-line';

@Component({
  selector: 'app-account-line',
  imports: [ReactiveFormsModule],
  templateUrl: './account-line.component.html',
  styleUrl: './account-line.component.css'
})
export class AccountLineComponent{
  readonly service = inject(AccountService);
  readonly enterComponent = inject(AccountEnterComponent);

  line : AccountLine | undefined = undefined;
  lineForm: FormGroup = new FormGroup({
    user: new FormControl("", {nonNullable : true, validators : [Validators.required]}),
    value: new FormControl("", {nonNullable : true, validators : [Validators.required]},)
  })

  deleteLine(id:number){
    if (id < 0) {
      this.deleteLineApi(id);
    }
    else{
      this.lineForm.reset();
    }
  }

  private deleteLineApi(id:number){
    if(this.service.http){
      this.service.http.get<boolean>("api/easycompta/AccountLine/delete" + id).subscribe({
        next: result => {
          if(result)  {
            this.enterComponent.deleteLine(id);
            this.lineForm.reset();
          }
        },
        error: error => console.log(error)
      });
    }
  }
  
}
