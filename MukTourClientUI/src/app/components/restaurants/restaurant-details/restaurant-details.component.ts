import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MapPinLocation } from 'src/app/_shared/models/map-pin-location.model';
import { Restaurant } from 'src/app/_shared/models/restaurant.model';
import { RestaurantsService } from 'src/app/_shared/services/restaurants.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.scss'],
})
export class RestaurantDetailsComponent implements OnInit {
  baseUrl: string;
  restaurant: Restaurant;
  locationPins: MapPinLocation[];
  constructor(
    private restaurantService: RestaurantsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.baseUrl = `${environment.baseUrl}/restaurants-api/restaurants/${id}/menu/`;

    this.restaurantService.getDetails(id).subscribe((data) => {
      this.restaurant = data;
      this.locationPins = [
        {
          lat: data.location.latitude,
          lng: data.location.longitude,
          title: data.name,
        },
      ];
    });
  }
}
