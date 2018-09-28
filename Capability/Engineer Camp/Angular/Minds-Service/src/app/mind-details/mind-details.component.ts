import { MyFirstService } from './../my-first.service';
import { Component, OnInit } from '@angular/core';
import {Mind} from '../mind';

@Component({
  selector: 'app-mind-details',
  templateUrl: './mind-details.component.html',
  styleUrls: ['./mind-details.component.css']
})
export class MindDetailsComponent implements OnInit {

  minds: Mind[];

  constructor(private _myService: MyFirstService) { }

    ngOnInit() {
      this.minds  = this._myService.getMindDetails();
    }

}
