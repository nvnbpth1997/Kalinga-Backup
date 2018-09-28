import { EventHandlerService } from './../shared/event-handler.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {

  list : Event[];
  constructor(private eventService : EventHandlerService) { }

  ngOnInit() {
  }

  getEvents() {
    this.eventService.getEvents().subscribe((data : Event[]) => 
  { 
    this.list = data;
  });
  }

}
