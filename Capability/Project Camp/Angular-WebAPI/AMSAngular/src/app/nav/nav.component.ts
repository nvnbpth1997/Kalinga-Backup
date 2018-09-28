import { FilterService } from './../filter.service';
import { Mind } from './../mind';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

selectedValue: number = null;
SwipedOnTime: boolean;
SwipedLate: boolean;
NotSwiped: boolean;

constructor(private filterService: FilterService) { }

ngOnInit() {
 }

 OnSubmit(value: number) {
   this.filterService.getDetails(value);
 }

 show() {
  this.filterService.getAllDetails();
 }

 default() {
   this.filterService.getDefaultDetails();
 }
}
