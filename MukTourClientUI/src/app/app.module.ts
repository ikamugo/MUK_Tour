import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';
import { MainContentComponent } from './components/layout/main-content/main-content.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ListEventsComponent } from './components/events/list-events/list-events.component';
import { EditEventComponent } from './components/events/edit-event/edit-event.component';
import { WeatherComponent } from './components/weather/weather.component';
import { ListRestaurantsComponent } from './components/restaurants/list-restaurants/list-restaurants.component';
import { ListProvidersComponent } from './components/service-providers/list-providers/list-providers.component';
import { ForecastDayComponent } from './components/weather/forecast-day/forecast-day.component';
import { CurrentConditionsComponent } from './components/weather/current-conditions/current-conditions.component';
import { CurrentReportComponent } from './components/weather/current-report/current-report.component';
import { ReportItemComponent } from './components/weather/current-report/report-item/report-item.component';
import { EventDetailsComponent } from './components/events/event-details/event-details.component';
import { EventSummaryComponent } from './components/events/list-events/event-summary/event-summary.component';
import { HttpClientModule } from '@angular/common/http';
import { TimePipe } from './_shared/pipes/time.pipe';
import { AgmCoreModule } from '@agm/core';
import { MapComponent } from './components/map/map.component';
import { MapServiceProvidersComponent } from './components/service-providers/map-service-providers/map-service-providers.component';
import { RestaurantDetailsComponent } from './components/restaurants/restaurant-details/restaurant-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    MainContentComponent,
    DashboardComponent,
    ListEventsComponent,
    EditEventComponent,
    WeatherComponent,
    ListRestaurantsComponent,
    ListProvidersComponent,
    ForecastDayComponent,
    CurrentConditionsComponent,
    CurrentReportComponent,
    ReportItemComponent,
    EventDetailsComponent,
    EventSummaryComponent,
    TimePipe,
    MapComponent,
    MapServiceProvidersComponent,
    RestaurantDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBtNcvziQJT_0YiN4MvTW2PT6VuX4ZeQTg'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
