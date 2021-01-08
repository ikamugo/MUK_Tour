import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {

  forecast = [

    {
      day: 'Mon',
      min: 14,
      max: 28
    },
    {
      day: 'Tue',
      min: 12,
      max: 23
    },
    {
      day: 'Wed',
      min: 10,
      max: 20
    },
    {
      day: 'Thu',
      min: 10,
      max: 20
    },
    {
      day: 'Fri',
      min: 10,
      max: 20
    },
    {
      day: 'Sat',
      min: 13,
      max: 14
    },
  ];

  forecast2 = [
    {
      day: 'Mon',
      min: 14,
      max: 28
    },
    {
      day: 'Tue',
      min: 12,
      max: 23
    },
    {
      day: 'Wed',
      min: 10,
      max: 20
    },
    {
      day: 'Thu',
      min: 10,
      max: 20
    },
    {
      day: 'Fri',
      min: 10,
      max: 20
    },
    {
      day: 'Sat',
      min: 13,
      max: 14
    },
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
