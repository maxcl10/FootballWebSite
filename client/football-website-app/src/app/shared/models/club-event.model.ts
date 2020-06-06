export class ClubEvent {
  id: string;
  name: string;
  startDate: Date;
  endDate?: Date;
  location: string;
  city: string;
  description?: string;
  imageUrl: string;
  canceled: boolean;
}
