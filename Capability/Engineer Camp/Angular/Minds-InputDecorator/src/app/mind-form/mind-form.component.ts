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
    // this.view();
  }

    Clear() {
      this.mind.name = null;
      this.mind.mid = null;
      this.mind.track = null;
    }
  constructor() { }

  ngOnInit() {
  }

}
