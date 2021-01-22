import { Component, Input, OnInit } from '@angular/core';
import { WeatherForecast } from 'src/app/_shared/models/weather-forecast.model';

@Component({
  selector: 'app-forecast-day',
  templateUrl: './forecast-day.component.html',
  styleUrls: ['./forecast-day.component.scss'],
})
export class ForecastDayComponent implements OnInit {
  @Input() forecast: WeatherForecast;
  constructor() {}

  ngOnInit(): void {}
}
