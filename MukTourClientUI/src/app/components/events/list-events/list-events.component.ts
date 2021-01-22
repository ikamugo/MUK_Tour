import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { EventSummary } from 'src/app/_shared/models/event-summary.model';
import { EventsService } from 'src/app/_shared/services/events.service';

@Component({
  selector: 'app-list-events',
  templateUrl: './list-events.component.html',
  styleUrls: ['./list-events.component.scss']
})
export class ListEventsComponent implements OnInit {

  events$: Observable<EventSummary[]>;

  constructor(private eventsService: EventsService) { }

  ngOnInit(): void {
    this.events$ = this.eventsService.listEvents();
  }

}
