export interface Restaurant {
  id: number;
  locationId: number;
  location: Location;
  name: string;
  logo?: any;
  phone?: any;
  email: string;
  rating: number;
  openHours: string;
  menus: Menu[];
}

export interface Menu {
  id: number;
  restaurantId: number;
  category?: any;
  name: string;
  description?: any;
  price: number;
}

export interface Location {
  id: number;
  latitude: number;
  longitude: number;
}
