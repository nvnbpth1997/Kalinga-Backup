import { FilterService } from './../filter.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dash1',
  templateUrl: './dash1.component.html',
  styleUrls: ['./dash1.component.css']
})
export class Dash1Component implements OnInit {

  constructor(private filterService: FilterService) { }

  ngOnInit() {
  }

}
