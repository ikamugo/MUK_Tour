import { EventSummary } from './event-summary.model';

export interface EventDetail extends EventSummary {
  posters: string[];
  description: string;
  startTime: string;
  endTime: string;
  organizer: string;
  organizerContacts: OrganizerContact[];
}

export interface OrganizerContact {
  type: string;
  contact: string;
}
