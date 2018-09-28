import { MyFirstService } from './../my-first.service';
import { Component, OnInit } from '@angular/core';
import {Mind} from '../mind';

@Component({
  selector: 'app-mind-form',
  templateUrl: './mind-form.component.html',
  styleUrls: ['./mind-form.component.css']
})
export class MindFormComponent implements OnInit {

  mind: Mind = {
    name: '',
    mid: '',
    track: ''
  };

  minds: Mind[] = [];

  AddComment(value1: string, value2: string, value3: string): void {
    this.minds.push(
      { name: value1, mid: value2, track: value3  }
    );
    this.Clear();
  }

    Clear() {
      this.mind.name = null;
      this.mind.mid = null;
      this.mind.track = null;
    }


  constructor(private _myService: MyFirstService) { }

  ngOnInit() {
    this._myService.setMindDetails(this.minds);
  }

}
