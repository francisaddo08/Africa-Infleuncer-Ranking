import { FormsModule } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import{ReactiveFormsModule, FormControl, } from '@angular/forms'

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  loginid: string = '';
  password: string = '';
  ngOnInit(): void {}

  Login() {
    
  }
}
