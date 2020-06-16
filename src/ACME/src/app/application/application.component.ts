import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from  '@angular/forms';
import { Router } from  '@angular/router';
import { AppService } from '../app.service';

@Component({
  selector: 'application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})
export class ApplicationComponent implements OnInit {

  private form

  constructor(private fb: FormBuilder, private appService: AppService) { }

  ngOnInit(): void {
    console.log(this.appService.getCountries());
  }

  private buildForm() {
    
  }

  submit() {

  }

}