import { EventHandlerService } from './shared/event-handler.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { EventFormComponent } from './event-form/event-form.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    EventFormComponent,
    EventDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [EventHandlerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
