import { Component, OnInit } from '@angular/core';
import {Minds} from '../shared/minds';

import { MindsService } from "src/app/shared/minds.service";


@Component({
  selector: "app-not-swiped",
  templateUrl: "./not-swiped.component.html",
  styleUrls: ["./not-swiped.component.css"]
})
export class NotSwipedComponent implements OnInit {
  constructor(public ms: MindsService) {}

  ngOnInit() {
    this.ms.getNotSwipe();
  }
  public p:any;
  public cols: number = 3;
  checkWidth() {
    var width = window.innerWidth;
    if (width <= 768) {
      this.cols = 1;
    } else if (width > 768 && width <= 992) {
      this.cols = 2;
    } else {
      this.cols = 3;
    }
  }
}
