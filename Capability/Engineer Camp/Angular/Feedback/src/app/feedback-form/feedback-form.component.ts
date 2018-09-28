import { Component, OnInit } from '@angular/core';
import {FeedbackForm} from '../Feedback';

@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})
export class FeedbackFormComponent implements OnInit {

  feedback: FeedbackForm = {
    name: '',
    mid: '',
    comment: '',
    date: null
  };

  feedbacks: FeedbackForm[] = [];

  constructor() { }
  ngOnInit() {
  }

  processForm() {
    this.feedbacks.push(
      {name: this.feedback.name, mid: this.feedback.mid, comment: this.feedback.comment, date: Date.now()}
    );
    this.clearForm();
  }

  clearForm() {
    this.feedback.name = null;
    this.feedback.mid = null;
    this.feedback.comment = null;
  }
}
