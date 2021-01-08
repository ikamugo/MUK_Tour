import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-forecast-day',
  templateUrl: './forecast-day.component.html',
  styleUrls: ['./forecast-day.component.scss']
})
export class ForecastDayComponent implements OnInit {
  @Input() name: string;
  @Input() max: number;
  @Input() min: number;
  constructor() { }

  ngOnInit(): void {
  }

}
