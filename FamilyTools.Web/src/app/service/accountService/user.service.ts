import { inject, Injectable } from '@angular/core';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService{

  private http = inject(HttpClient);
  
  Users : User[] = [];
  
  UserSelected : User|undefined;

  constructor(){
    console.log("construc user service")
    this.getUserListApi();
  }

    public async getUserListApi(){
    if(this.http)
      {
        this.http.get<User[]>('/api/user').subscribe({
          next: result => this.Users = result,
          error: console.error
        });
      }
  }

  public async createUserApi(user: User){
    if(this.http)
      {
        this.http.post<User>('/api/user/create', user).subscribe({
          next: result => {
            console.log(`${result.firstName} ${result.lastName} a été ajouté`);
            this.getUserListApi();
          },
          error: console.error
        });
      }
  }

  public async deleteUserApi(id:number){
    if(this.http)
      {
        this.http.delete<boolean>('/api/user/delete/' + id).subscribe({
          next: result => result ? this.Users = this.Users.filter(user => user.id != id) : null,
          error: console.error
        });
      }
  }

  public async getUser(id:number){
    if (this.http) {
      this.http.get<User>('/api/user/index/' + id).subscribe({
        next: result => this.UserSelected = result,
        error: console.error
      })
    }
  }
  
  public async updateUserApi(){
    if(this.http)
      {
        this.http.put<User>('/api/user/edit', this.UserSelected).subscribe({
          next: result => this.Users.map( user => user.id == result.id? user = result : null),
          error: console.error
        });
      }
  }

}
