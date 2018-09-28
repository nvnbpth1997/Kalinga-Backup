import { MobileDetailsService } from '../mobile-details.service';
import {Observable} from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointState, BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  /** Based on the screen size, switch from standard to one column per row */
  // cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
  //   map(({ matches }) => {
  //     if (matches) {
  //       return [
  //         { title: 'Samsung Galaxy J6 (Blue, 32 GB)  (4 GB RAM)', cols: 1, rows: 1,
  //         path: '/assets/samsung-galaxy-j6.jpeg', cost: 'Rs. 12,990', rom: '32 GB', ram: '4 GB RAM', os:'Android'},
  //         { title: 'Samsung Galaxy J3 Pro (Gold, 16 GB) (2 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/samsung-galaxy-j3.jpeg', cost: 'Rs. 7,490', rom: '16 GB', ram: '4 GB RAM', os:'Android' },
  //         { title: 'Sony Xperia R1 Plus Dual (Silver, 32 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/sony-xperia-l2-dual.jpeg', cost: 'Rs. 12,499', rom: '32 GB', ram: '4 GB RAM', os:'Android'},
  //         { title: 'Sony Xperia L2 Dual (Black, 32 GB)  (2 GB RAM)', cols: 1, rows: 1,
  //          path: '/assets/sony-xperia-r1-plus.jpeg', cost: 'Rs. 14,990', rom: '32 GB', ram: '2 GB RAM' , os:'Android' },
  //         { title: 'HTC U ULtra (Sapphire Blue, 64 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/htc-u-ultra-u-ultra.jpeg', cost: 'Rs. 27,390', rom: '64 GB', ram: '4 GB RAM', os:'Android' },
  //         { title: 'HTC Desire 816G (Octa Core) (Blue, 16 GB)  (1 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/htc-desire-816g.jpeg', cost: 'Rs. 16,751', rom: '16 GB', ram: '1 GB RAM', os:'Android'},
  //         { title: 'Apple iPhone SE (Space Grey, 32 GB)', cols: 1, rows: 1,
  //          path: '/assets/apple-iphone-se.jpeg', cost: 'Rs. 17,999', rom: '32 GB', ram: '1 GB RAM', os:'iOS' },
  //         { title: 'Apple iPhone 6s (Gold, 32 GB)', cols: 1, rows: 1,
  //         path:'/assets/apple-iphone-6s.jpeg', cost: 'Rs. 33,999', rom: '32 GB', ram: '2 GB RAM', os:'iOS'  },
  //         { title: 'Nokia 5 (Tempered Blue, 16 GB)  (2 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/nokia-5.jpeg', cost: 'Rs. 12,499', rom: '16 GB', ram: '2 GB RAM', os:'Windows'  },
  //         { title: 'Nokia 7 Plus (Black & Copper, 64 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //         path: '/assets/nokia-7-plus.jpeg', cost: 'Rs. 26,990', rom: '64 GB', ram: '4 GB RAM', os:'Windows'  },
  //         { title: 'OnePlus 6 (Mirror Black 6GB RAM + 64GB Memory)', cols: 1, rows: 1, 
  //         path: '/assets/one plus 6.jpg', cost: 'Rs. 34,999', rom: '64 GB', ram: '6 GB RAM', os:'Android'  },
  //         { title: 'OnePlus 3T (Gunmetal, 6GB RAM + 64GB Memory)', cols: 1, rows: 1, 
  //         path: '/assets/one plus 3.jpg', cost: 'Rs. 25,999', rom: '64 GB', ram: '6 GB RAM' , os:'Android' }
  //       ];
  //     }

  //     return [
  //       { title: 'Samsung Galaxy J6 (Blue, 32 GB)  (4 GB RAM)', cols: 1, rows: 1,
  //       path: '/assets/samsung-galaxy-j6.jpeg', cost: 'Rs. 12,990', rom: '32 GB', ram: '4 GB RAM', os:'Android'},
  //       { title: 'Samsung Galaxy J3 Pro (Gold, 16 GB) (2 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/samsung-galaxy-j3.jpeg', cost: 'Rs. 7,490', rom: '16 GB', ram: '4 GB RAM', os:'Android' },
  //       { title: 'Sony Xperia R1 Plus Dual (Silver, 32 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/sony-xperia-l2-dual.jpeg', cost: 'Rs. 12,499', rom: '32 GB', ram: '4 GB RAM', os:'Android'},
  //       { title: 'Sony Xperia L2 Dual (Black, 32 GB)  (2 GB RAM)', cols: 1, rows: 1,
  //        path: '/assets/sony-xperia-r1-plus.jpeg', cost: 'Rs. 14,990', rom: '32 GB', ram: '2 GB RAM' , os:'Android' },
  //       { title: 'HTC U ULtra (Sapphire Blue, 64 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/htc-u-ultra-u-ultra.jpeg', cost: 'Rs. 27,390', rom: '64 GB', ram: '4 GB RAM', os:'Android' },
  //       { title: 'HTC Desire 816G (Octa Core) (Blue, 16 GB)  (1 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/htc-desire-816g.jpeg', cost: 'Rs. 16,751', rom: '16 GB', ram: '1 GB RAM', os:'Android'},
  //       { title: 'Apple iPhone SE (Space Grey, 32 GB)', cols: 1, rows: 1,
  //        path: '/assets/apple-iphone-se.jpeg', cost: 'Rs. 17,999', rom: '32 GB', ram: '1 GB RAM', os:'iOS' },
  //       { title: 'Apple iPhone 6s (Gold, 32 GB)', cols: 1, rows: 1,
  //       path:'/assets/apple-iphone-6s.jpeg', cost: 'Rs. 33,999', rom: '32 GB', ram: '2 GB RAM', os:'iOS'  },
  //       { title: 'Nokia 5 (Tempered Blue, 16 GB)  (2 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/nokia-5.jpeg', cost: 'Rs. 12,499', rom: '16 GB', ram: '2 GB RAM', os:'Windows'  },
  //       { title: 'Nokia 7 Plus (Black & Copper, 64 GB)  (4 GB RAM)', cols: 1, rows: 1, 
  //       path: '/assets/nokia-7-plus.jpeg', cost: 'Rs. 26,990', rom: '64 GB', ram: '4 GB RAM', os:'Windows'  },
  //       { title: 'OnePlus 6 (Mirror Black 6GB RAM + 64GB Memory)', cols: 1, rows: 1, 
  //       path: '/assets/one plus 6.jpg', cost: 'Rs. 34,999', rom: '64 GB', ram: '6 GB RAM', os:'Android'  },
  //       { title: 'OnePlus 3T (Gunmetal, 6GB RAM + 64GB Memory)', cols: 1, rows: 1, 
  //       path: '/assets/one plus 3.jpg', cost: 'Rs. 25,999', rom: '64 GB', ram: '6 GB RAM' , os:'Android' }
  //     ];
  //   })
  // );
  constructor(private mob: MobileDetailsService) { }

  public mobiles = [];

  ngOnInit() {
    this.getDet();
  }

  getDet() {
      this.mob.getMobile().subscribe(data => this.mobiles = data);
   }
}



