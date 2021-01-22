import { Venue } from './venue.model';

export interface EventSummary {
  id: string;
  title: string;
  category: string;
  date: string;
  price: number;
  venue: Venue;
}
