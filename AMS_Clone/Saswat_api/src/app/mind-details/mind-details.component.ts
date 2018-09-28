import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MindsService } from "src/app/shared/minds.service";
import { Minds } from '../shared/minds';
import { NgModule } from'@angular/core';

@Component({
  selector: 'app-mind-details',
  templateUrl: './mind-details.component.html',
  styleUrls: ['./mind-details.component.css']
})
export class MindDetailsComponent implements OnInit {
  mind:Minds;

  constructor(
    private route:ActivatedRoute,
    private ms:MindsService) { }

  ngOnInit() {
    this.getMind();
  }
  getMind() {
    const mid = this.route.snapshot.paramMap.get('mid');
    this.ms.getMind(mid).subscribe(x => (this.mind = x));
  }

}


