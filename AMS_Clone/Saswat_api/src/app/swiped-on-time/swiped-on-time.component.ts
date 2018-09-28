import { Component, OnInit } from '@angular/core';
import { MindsService } from "src/app/shared/minds.service";
import {Minds} from '../shared/minds';
import {NgModule} from'@angular/core';


@Component({
  selector: 'app-swiped-on-time',
  templateUrl: './swiped-on-time.component.html',
  styleUrls: ['./swiped-on-time.component.css'],
  providers:[MindsService]
})
export class SwipedOnTimeComponent implements OnInit {

  constructor(public ms:MindsService) { }

  ngOnInit() {
    this.ms.getOnTimeList();
  }
  public p:any;
  public cols: number=3;
  checkWidth()
  { var width = window.innerWidth;
  if (width <= 768) {
  this.cols=1;
  } else if (width > 768 && width<=992) {
  this.cols=2;
  } 
  else{
  this.cols=3;
  }
  } 
  

}



