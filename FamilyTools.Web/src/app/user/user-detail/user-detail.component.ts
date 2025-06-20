import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../models/user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-userdetail',
  imports: [],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css',
})
export class UserDetailComponent{

  private service = inject(UserService);
  
  updateUser(){
    this.service.updateUserApi();
  }
}
