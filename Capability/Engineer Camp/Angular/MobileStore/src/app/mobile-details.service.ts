import { Observable } from 'rxjs';
import { IMobile } from './IMobile';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MobileDetailsService {
  private url: string;
  constructor(private http: HttpClient) {
    this.url = '/assets/data/MobileStore.json';
    }

    getMobile(): Observable <IMobile[]> {
      return this.http.get<IMobile[]>(this.url);
    }
}
