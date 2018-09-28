import { Routes } from '@angular/router';
import { FilterService } from './../filter.service';
import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-dash',
  templateUrl: './dash.component.html',
  styleUrls: ['./dash.component.css']
})
export class DashComponent implements OnInit {

  constructor(private filterService: FilterService) { }

  ngOnInit() {
    this.filterService.getAllDetails();
  }

  details(id: number) {
    this.filterService.getEmployee(id);
  }
}
