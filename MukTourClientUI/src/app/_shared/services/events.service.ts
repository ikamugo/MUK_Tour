import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EventDetail } from '../models/event-detail.model';
import { EventSummary } from '../models/event-summary.model';

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  private baseUrl = `${environment.baseUrl}/events-api`;
  constructor(private httpClient: HttpClient) { }

  listEvents(): Observable<EventSummary[]> {
    return this.httpClient.get<EventSummary[]>(`${this.baseUrl}/events`);
  }

  getEventDetails(id: string): Observable<EventDetail> {
    return this.httpClient.get<EventDetail>(`${this.baseUrl}/events/${id}`);
  }
}
