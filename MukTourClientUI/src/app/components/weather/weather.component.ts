import { Component, OnInit } from '@angular/core';
import { WeatherForecast } from 'src/app/_shared/models/weather-forecast.model';
import { WeatherService } from 'src/app/_shared/services/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss'],
})
export class WeatherComponent implements OnInit {
  forecast: WeatherForecast[];
  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    const location = 'makerere university';
    this.weatherService.getForecast(location).subscribe((data) => {
      this.forecast = data;
    });
  }

  get currentWeather(): WeatherForecast {
    return this.forecast ? this.forecast[0] : null;
  }
}
