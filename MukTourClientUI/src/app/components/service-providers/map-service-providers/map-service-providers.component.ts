import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { MapPinLocation } from 'src/app/_shared/models/map-pin-location.model';
import { ServiceProvider } from 'src/app/_shared/models/service-provider.model';
import { ServiceProvidersService } from 'src/app/_shared/services/service-providers.service';

@Component({
  selector: 'app-map-service-providers',
  templateUrl: './map-service-providers.component.html',
  styleUrls: ['./map-service-providers.component.scss'],
})
export class MapServiceProvidersComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();
  category: string;
  pinLocations: MapPinLocation[];
  constructor(
    private providersService: ServiceProvidersService,
    private route: ActivatedRoute
  ) {}

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe((params) => {
      this.category = params.category;
      this.pinLocations = [];
      this.providersService
        .getServiceProviders(this.category)
        .subscribe((data) => {
          this.pinLocations = data.map((x) => {
            return { lat: x.position.lat, lng: x.position.lng, title: x.name };
          });
        });
    });
  }
}
