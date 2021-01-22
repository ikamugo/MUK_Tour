import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { WeatherForecast } from '../models/weather-forecast.model';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  private baseUrl = `${environment.baseUrl}/weather-api`;
  constructor(private httpClient: HttpClient) {}

  getForecast(location: string): Observable<WeatherForecast[]> {
    const params = new HttpParams().set('location', location);
    return this.httpClient.get<WeatherForecast[]>(`${this.baseUrl}/forecast`, {
      params,
    });
  }
}
