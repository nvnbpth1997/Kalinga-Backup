import { MyFirstService } from './my-first.service';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MindFormComponent } from './mind-form/mind-form.component';
import { MindDetailsComponent } from './mind-details/mind-details.component';

@NgModule({
  declarations: [
    AppComponent,
    MindFormComponent,
    MindDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [MyFirstService],
  bootstrap: [AppComponent]
})
export class AppModule { }
