import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Restaurant } from 'src/app/_shared/models/restaurant.model';
import { RestaurantsService } from 'src/app/_shared/services/restaurants.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-list-restaurants',
  templateUrl: './list-restaurants.component.html',
  styleUrls: ['./list-restaurants.component.scss'],
})
export class ListRestaurantsComponent implements OnInit {
  baseUrl = `${environment.baseUrl}/restaurants-api/restaurants/`;
  restaurants$: Observable<Restaurant[]>;
  constructor(private restaurantsService: RestaurantsService) {}

  ngOnInit(): void {
    this.restaurants$ = this.restaurantsService.listRestaurants();
  }

  getRatingStars(rating: number): string[] {
    const stars = [];
    for (let count = 1; count <= 5; count++) {
      if (rating >= count) {
        stars.push('fa fa-star');
      } else if (rating < count && rating > count - 1) {
        stars.push('fa fa-star-half-alt');
      }
      else{
        stars.push('far fa-star');
      }
    }
    return stars;
  }
}
