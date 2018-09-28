import { Mind } from './mind';
import { Injectable, OnInit } from '@angular/core';
// import {Http, Response, Headers, RequestOptions, RequestMethod} from '@angular/http';
import { map } from 'rxjs/operators';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class FilterService implements OnInit {

  minds: Mind[];
  mind: Mind = {
    ID: null,
    FirstName: '',
    LastName: '',
    Email: '',
    MID: '' ,
    Mobile: '',
    Gender: '',
    SwipeInTime: '',
    SwipeStatus: null
  };
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  getDetails(value: number) {
      this.http.get('http://localhost:55631/api/AMSModels/BySwipe/' + value)
      .subscribe((x: Mind[]) => (this.minds = x));
    }

    getAllDetails() {
      this.http.get('http://localhost:55631/api/AMSModels')
      .subscribe( (x: Mind[]) => this.minds = x);
    }

    getEmployee(id: number) {
      this.http.get('http://localhost:55631/api/AMSModels/' + id)
      .subscribe((x: Mind) => this.mind = x );
    }
  }

