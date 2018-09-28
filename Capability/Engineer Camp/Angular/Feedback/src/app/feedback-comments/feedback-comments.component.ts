import { Component, OnInit, Input } from '@angular/core';
import {FeedbackForm} from '../Feedback';

@Component({
  selector: 'app-feedback-comments',
  templateUrl: './feedback-comments.component.html',
  styleUrls: ['./feedback-comments.component.css']
})
export class FeedbackCommentsComponent implements OnInit {

  @Input() details: FeedbackForm[];
  constructor() { }

  ngOnInit() {
  }

}
