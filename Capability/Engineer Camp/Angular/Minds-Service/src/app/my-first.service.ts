import { Mind } from './mind';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MyFirstService {
  mindDetails: Mind[];

  constructor() {
    this.mindDetails = null;
  }

  setMindDetails(mind: Mind[]) {
    this.mindDetails = mind;
  }

  getMindDetails(): Mind[] {
    return this.mindDetails;
  }
}
