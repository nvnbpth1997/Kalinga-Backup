import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
  template: `
  <h1>Login</h1>
  <input #textbox1 type="text" [(ngModel)]="textValue1">&nbsp;
  <input #textbox2 type="text" [(ngModel)]="textValue2">&nbsp;
  <button (click)="Validate(textbox1.value, textbox2.value)">Submit</button><br>
  {{log}}`
})

export class FormComponent implements OnInit{
  log = '';
  Validate(value1: string, value2: string): void {
    this.log += `The username is '${value1}' and the password is '${value2}'\n`;
  }

  constructor() { }
    ngOnInit() {
    }

}
