import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditEventComponent } from './components/events/edit-event/edit-event.component';
import { EventDetailsComponent } from './components/events/event-details/event-details.component';
import { ListEventsComponent } from './components/events/list-events/list-events.component';
import { MapComponent } from './components/map/map.component';
import { ListRestaurantsComponent } from './components/restaurants/list-restaurants/list-restaurants.component';
import { RestaurantDetailsComponent } from './components/restaurants/restaurant-details/restaurant-details.component';
import { ListProvidersComponent } from './components/service-providers/list-providers/list-providers.component';
import { MapServiceProvidersComponent } from './components/service-providers/map-service-providers/map-service-providers.component';
import { WeatherComponent } from './components/weather/weather.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: 'dashboard',
    component: MapComponent
  },
  {
    path: 'events',
    component: ListEventsComponent
  },
  {
    path: 'events/create',
    component: EditEventComponent
  },
  {
    path: 'events/details/:id',
    component: EventDetailsComponent
  },
  {
    path: 'weather',
    component: WeatherComponent
  },
  {
    path: 'restaurants',
    component: ListRestaurantsComponent
  },
  {
    path: 'restaurants/:id',
    component: RestaurantDetailsComponent
  },
  {
    path: 'services',
    component: ListProvidersComponent,
    children: [
      {
        path: ':category',
        component: MapServiceProvidersComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
