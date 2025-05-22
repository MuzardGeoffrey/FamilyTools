import { Component } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})

export class UserComponent {
  users : User[] = [];
  
    userform = new FormGroup({
      firstName : new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
      lastName: new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
      userName : new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
  });

  constructor(private http: HttpClient)
  {
    this.get_user_list();
  }

  updateUserForm(){
    let user : User = {
      firstName: this.userform.getRawValue().firstName,
      lastName: this.userform.getRawValue().firstName,
      userName: this.userform.getRawValue().firstName,
    };

    this.create_user(user);
  }

  public async get_user_list(){
    if(this.http)
      {
        this.http.get<User[]>('api/easycompta/user').subscribe({
          next: result => this.users = result,
          error: console.error
        });
      }
  }

  public async create_user(user: User){
    if(this.http)
      {
        this.http.post<User>('api/easycompta/user/create', user).subscribe({
          next: result => this.users.push(result),
          error: console.error
        });
      }
  }

  public async update_user(user:User){
    if(this.http)
      {
        this.http.put<User>('api/easycompta/user/edit', user).subscribe({
          next: result => this.users.map( user => user.id == result.id? user = result : null),
          error: console.error
        });
      }
  }

}