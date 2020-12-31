import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ListEventsComponent } from './components/events/list-events/list-events.component';
import { ListRestaurantsComponent } from './components/restaurants/list-restaurants/list-restaurants.component';
import { ListProvidersComponent } from './components/service-providers/list-providers/list-providers.component';
import { WeatherComponent } from './components/weather/weather.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'events',
    component: ListEventsComponent
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
    path: 'services',
    component: ListProvidersComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
