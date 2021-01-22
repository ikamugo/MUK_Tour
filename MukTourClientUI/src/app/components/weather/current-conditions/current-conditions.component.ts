import { Component, Input, OnInit } from '@angular/core';
import { WeatherForecast } from 'src/app/_shared/models/weather-forecast.model';

@Component({
  selector: 'app-current-conditions',
  templateUrl: './current-conditions.component.html',
  styleUrls: ['./current-conditions.component.scss']
})
export class CurrentConditionsComponent implements OnInit {
  @Input() forecast: WeatherForecast;
  constructor() { }

  ngOnInit(): void {
  }

}
