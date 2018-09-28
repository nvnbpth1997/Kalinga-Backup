import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EventHandlerService {

  baseUrl = 'http://localhost:55816/';

  constructor(private httpClient : HttpClient) { }

  postEvent(event: Event) {
    return this.httpClient.post(this.baseUrl + "api/Events", event);
  }

  getEvents() {
    return this.httpClient.get(this.baseUrl + "api/Events");
  }
}
