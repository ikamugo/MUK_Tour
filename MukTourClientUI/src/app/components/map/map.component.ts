import { Component, Input, OnInit } from '@angular/core';
import { MapPinLocation } from 'src/app/_shared/models/map-pin-location.model';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {

 @Input() mapPins: MapPinLocation[];
 @Input() zoom = 17;
  constructor() { }

  ngOnInit(): void {
  }

  get centerLat(): number {
    return this.mapPins ? this.mapPins[0]?.lat : 0.33363;
  }

  get centerLng(): number {
    return this.mapPins ? this.mapPins[0]?.lng : 32.56737;
  }
}
