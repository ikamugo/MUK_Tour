export interface ServiceProvider {
  name: string;
  position: Position;
  distance: number;
  categories: string[];
  contact: Contact;
}

export interface Contact {
  email: string[];
  phone: string[];
  website: string[];
}

export interface Position {
  lat: number;
  lng: number;
}
