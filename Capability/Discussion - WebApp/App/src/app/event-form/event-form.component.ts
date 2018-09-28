import { EventHandlerService } from './../shared/event-handler.service';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormGroup } from "@angular/forms";

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent implements OnInit {

  constructor(private eventService : EventHandlerService) { 
    // this.eventForm.controls['eventName'].setValue('Select');
  }

  ngOnInit() {
  }

  eventForm = new FormGroup({
  eventName: new FormControl(''),
  participantName: new FormControl('')
  });

  eventsList =  [
    // {id: 0, name: 'None'},
    {id: 1, name: 'Singing'},
    {id: 2, name: 'Dancing'},
    ];

    postEvent(){
          console.log(this.eventForm.value);
          this.eventService.postEvent(this.eventForm.value).subscribe( response =>
            {
                console.log('done');
            });
            this.eventForm.reset();
    }
}
