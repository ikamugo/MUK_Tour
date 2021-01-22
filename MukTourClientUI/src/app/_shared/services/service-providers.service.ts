import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ServiceProvider } from '../models/service-provider.model';

@Injectable({
  providedIn: 'root'
})
export class ServiceProvidersService {
  private baseUrl = `${environment.baseUrl}/serviceproviders-api`;
  constructor(private httpClient: HttpClient) { }

  listCategories(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.baseUrl}/categories`);
  }

  getServiceProviders(category: string): Observable<ServiceProvider[]> {
    return this.httpClient.get<ServiceProvider[]>(`${this.baseUrl}/${category}`);
  }
}
