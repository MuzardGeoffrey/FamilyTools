import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { AccountTag } from '../../models/account-tag';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-accounttag',
  imports: [ReactiveFormsModule],
  templateUrl: './account-tag.component.html',
  styleUrl: './account-tag.component.css'
})
export class AccountTagComponent implements OnInit{
  http = inject(HttpClient)
  tags : AccountTag[] = []

  tagForm : FormGroup = new FormGroup({
      name: new FormControl('',{nonNullable : true, validators: [Validators.required, Validators.minLength(3)]}),
      color: new FormControl('',{nonNullable : true, validators: [Validators.required]})
  });

  ngOnInit(): void {
    this.getTagListApi()
  }

    isSubmit:boolean = false;
  
  get name(){
    return this.tagForm.get('name')
  }

  get color(){
    return this.tagForm.get('color')
  }

  private getTagListApi(){
    if (this.http) {
      this.http.get<AccountTag[]>("api/easycompta/AccountTag").subscribe({
        next: result => this.tags = result,
        error: error => console.log(error)
      });
    }
  }

  private createTagApi(tag : AccountTag){
    if (this.http) {
      this.http.post<AccountTag>("api/easycompta/AccountTag/create", tag).subscribe({
        next: result => {
            console.log(`le tag ${result.name} avec la couleur ${result.color} a été ajouté`);
            this.getTagListApi();
          },
        error: error => console.log(error)
      });
    }
  }

  private deleteTagApi(id:number){
    if(this.http){
      this.http.get<boolean>("api/easycompta/AccountTag/delete" + id).subscribe({
        next: result => result ? this.getTagListApi() : null,
        error: error => console.log(error)
      });
    }
  }

  createTag(){
    let tag : AccountTag = {
      name: this.tagForm.getRawValue().name,
      color: this.tagForm.getRawValue().color,
    };
    this.createTagApi(tag);
  }

  deleteTag(id:number){
    this.deleteTagApi(id);
  }
}
