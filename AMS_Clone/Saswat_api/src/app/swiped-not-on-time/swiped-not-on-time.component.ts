import { Component, OnInit } from '@angular/core';
import {Minds} from '../shared/minds';
import { MatTabChangeEvent } from "@angular/material";
import { MindsService } from "src/app/shared/minds.service";
import { Exportfile } from "src/app/shared/exportfile";

@Component({
  selector: "app-swiped-not-on-time",
  templateUrl: "./swiped-not-on-time.component.html",
  styleUrls: ["./swiped-not-on-time.component.css"]
})
export class SwipedNotOnTimeComponent implements OnInit {
  constructor(public ms: MindsService) {}

  filterrepeateddefaulters = [
    { id: 0, name: "None"},
    { id: 1, name: "Last Week" },
    { id: 2, name: "Last Month" },
    { id: 3, name: "Last Three Months" }
  ];
  data: Exportfile[] = [];
  support: Exportfile = new Exportfile();
  defaultvalue = 0;
  refno: number;
  reference: string;
  r:string;
  ngOnInit() {
    //localStorage.removeItem("userToken");
    this.ms.getLateSwipe();
    // this.ms.getRepeatDefaulters();
  }
  getRepeatDefaulter(event: MatTabChangeEvent) {
    
    let selectedTab = event.tab;
    console.log(selectedTab);
    if ("Repeated Defaulters" === event.tab.textLabel) {
      
      this.ms.getRepeatDefaulters();
      
    } else if("Defaulters" === event.tab.textLabel){
      
      this.ms.getLateSwipe();
    }
    else{
      this.reference='LTD';
      this.ms.getFilteredDefaulters('1');
    }
     
  }
  public p: any;
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
  OnFilter(value: any)
  {
    if(value == '1')
      this.refno=1;
    if(value == '2')
      this.refno=2;
    if(value == '3')
      this.refno=3;
    if(value == '4')
      this.refno=4;
    if(value == '5')
      this.refno=5;
      this.ms.getFilteredDefaulters(value);
  }
  ExportAsExcel(dataminds : Minds[])
  {
    for(var items of dataminds)
{
this.support.FirstName = items.FirstName;
this.support.LastName = items.LastName;
this.support.Email = items.Email;
this.support.Mid = items.Mid;
this.support.PhoneNo = items.PhoneNo;
this.support.LateSwipe = items.LateSwipe;
this.support.NotSwipe = items.NotSwipe;
this.data.push(this.support);
this.support = new Exportfile();
}
    this.ms.exportAsExcelFile(this.data, this.refno);
  }
}
