export interface Venue {
  id: string;
  name: string;
  type: string;
  location: Location;
}

export interface Location {
  latitude: number;
  longitude: number;
}
