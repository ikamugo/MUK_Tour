import { Component, Input, OnInit } from '@angular/core';
import { EventSummary } from 'src/app/_shared/models/event-summary.model';

@Component({
  selector: 'app-event-summary',
  templateUrl: './event-summary.component.html',
  styleUrls: ['./event-summary.component.scss']
})
export class EventSummaryComponent implements OnInit {

  @Input() scheduledEvent: EventSummary;
  constructor() { }

  ngOnInit(): void {
  }
}
