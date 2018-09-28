import { Component, OnInit } from '@angular/core';
import {Settings} from '../shared/settings';
import { MindsService } from "src/app/shared/minds.service";
import { NgForm } from "@angular/forms";
import Swal from 'sweetalert2';
@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  constructor(public ms: MindsService) { }

  ngOnInit() {
    this.resetform();
  }
  submit(form: NgForm)
  {
    this.ms.postSettings(form.value);
    Swal({
      position: "center",
      type: "success",
      title: "Upload Successful",
      showConfirmButton: false,
      timer: 5000
    });
    this.resetform();
  }
  resetform(form?: NgForm)
  {
    if(form != null)
      {
        form.reset();
        this.ms.getSettings('C1');
      }
      
      this.ms.settingsdetails = {
        Time : '',
        Thresholdcount : null,
        NotswipeText : '',
        Category: '',
        LateswipeText : '',  
      }
  }
  select(value : any)
  {
    if(value!='')
      this.ms.getSettings(value);
  }
}
