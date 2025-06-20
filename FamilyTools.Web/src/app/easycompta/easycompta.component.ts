import { Component, Injectable, OnInit, inject } from '@angular/core';
import { AccountPage } from '../models/account-page';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Injectable()
@Component({
  selector: 'app-easycompta',
  standalone: true,
  templateUrl: './easycompta.component.html',
  styleUrl: './easycompta.component.css',
  imports: [RouterOutlet],
})
export class EasycomptaComponent{

  title = 'EasyCompta';
}
