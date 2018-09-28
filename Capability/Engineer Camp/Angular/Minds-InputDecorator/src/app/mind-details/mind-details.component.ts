import { Mind } from './../mind';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-mind-details',
  templateUrl: './mind-details.component.html',
  styleUrls: ['./mind-details.component.css']
})

export class MindDetailsComponent implements OnInit {

  @Input() mind: Mind[];
  constructor() { }

  ngOnInit() {
  }

}
