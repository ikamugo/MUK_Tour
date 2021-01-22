import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Restaurant } from '../models/restaurant.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantsService {

  private baseUrl = `${environment.baseUrl}/restaurants-api`;
  constructor(private httpClient: HttpClient) { }

  listRestaurants(): Observable<Restaurant[]> {
    return this.httpClient.get<Restaurant[]>(`${this.baseUrl}/restaurants`);
  }

  getDetails(id: number): Observable<Restaurant> {
    return this.httpClient.get<Restaurant>(`${this.baseUrl}/restaurants/${id}`);
  }
}
