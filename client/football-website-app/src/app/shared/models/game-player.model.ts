import { Event } from '../../shared/models/event.model';

export class GamePlayer {
  id: string;
  playerId: string;
  position: string;
  playerFirstName: string;
  playerLastName: string;
  events: Event[];
}
