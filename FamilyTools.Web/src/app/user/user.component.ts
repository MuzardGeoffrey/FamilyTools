import { Component } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  imports: [ReactiveFormsModule]
})

export class UserComponent {
  users : User[] = [];
  
    userform : FormGroup = new FormGroup({
      firstname : new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
      lastname: new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
      username : new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
  });

  isSubmit:boolean = false;

  constructor(private http: HttpClient)
  {
    this.get_user_list();
  }

  // form
  get firstname(){
    return this.userform.get('firstname')
  }

  get lastname(){
    return this.userform.get('lastname')
  }

  get username(){
    return this.userform.get('username')
  }

  onSubmit(){
    this.isSubmit = true;

    if(this.userform.valid){
        let user : User = {
          firstName: this.userform.getRawValue().firstname,
          lastName: this.userform.getRawValue().lastname,
          userName: this.userform.getRawValue().username,
        };
        this.create_user(user);
    }

  }

  public async get_user_list(){
    if(this.http)
      {
        this.http.get<User[]>('/api/user').subscribe({
          next: result => this.users = result,
          error: console.error
        });
      }
  }

  public async create_user(user: User){
    if(this.http)
      {
        this.http.post<User>('/api/user/create', user).subscribe({
          next: result => this.users.push(result),
          error: console.error
        });
          console.log("users");
          console.log(this.users);
      }
  }

  public async update_user(user:User){
    if(this.http)
      {
        this.http.put<User>('/api/user/edit', user).subscribe({
          next: result => this.users.map( user => user.id == result.id? user = result : null),
          error: console.error
        });
      }
  }

}