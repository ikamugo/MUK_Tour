import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { EventDetail } from 'src/app/_shared/models/event-detail.model';
import { WeatherForecast } from 'src/app/_shared/models/weather-forecast.model';
import { EventsService } from 'src/app/_shared/services/events.service';
import { WeatherService } from 'src/app/_shared/services/weather.service';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { MapPinLocation } from 'src/app/_shared/models/map-pin-location.model';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.scss'],
})
export class EventDetailsComponent implements OnInit {
  scheduledEvent: EventDetail;
  pinLocations: MapPinLocation[];
  forecast: WeatherForecast;
  postersBaseUrl = `${environment.baseUrl}/events-api/posters/`;
  constructor(
    private eventsService: EventsService,
    private weatherService: WeatherService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.eventsService.getEventDetails(id).subscribe((data) => {
      this.scheduledEvent = data;
      this.pinLocations = [
        {
          lat: data.venue.location.latitude,
          lng: data.venue.location.longitude,
          title: data.venue.name,
        }
      ];

      // get weather forecast if date is 2 days away
      const now = moment();
      const evDate = moment(this.scheduledEvent.date);
      if (evDate.diff(now, 'days') + 1 <= 2 && evDate.isAfter(now)) {
        const eventLocation = `${this.scheduledEvent.venue.location.latitude},${this.scheduledEvent.venue.location.longitude}`;
        this.weatherService.getForecast(eventLocation).subscribe((weather) => {
          this.forecast = weather.find((x) =>
            evDate.startOf('day').isSame(moment(x.date).startOf('day'))
          );
        });
      }
    });
  }

  getContactIcon(type: string): string {
    if (type === 'Email') {
      return 'fa fa-envelope';
    } else {
      return 'fa fa-phone';
    }
  }
}
