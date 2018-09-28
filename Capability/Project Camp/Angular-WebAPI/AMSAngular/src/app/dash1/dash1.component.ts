import { Router } from '@angular/router';
import { FilterService } from './../filter.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dash1',
  templateUrl: './dash1.component.html',
  styleUrls: ['./dash1.component.css']
})
export class Dash1Component implements OnInit {

info =  [
{id: 1, name: 'None'},
{id: 2, name: 'Last Month'},
{id: 3, name: 'Last 3 Months'}
];

last: number;
isImageLoading: boolean;

  constructor(private filterService: FilterService) {  }

  ngOnInit() {
    this.last = 1;
    this.filterService.getDefaultDetails();
    this.filterService.getImages();
  }

   retrieveByDate() {
     this.filterService.getTrackByDate();
   }

test(val: string) {
  if (val === '3') {
    this.filterService.value = -3;
  } else if (val === '2') {
    this.filterService.value = -1;
  } else {
    this.filterService.value = 0;
  }
  this.filterService.getTrackDetails();
}

// getImageFromService(mid: string) {
//   this.isImageLoading = true;
//   this.filterService.getImage(mid);
//   this.isImageLoading = false;
// }

}
