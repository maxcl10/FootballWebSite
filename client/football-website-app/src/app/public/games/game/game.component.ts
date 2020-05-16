import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../../shared/models/game.model';

@Component({
  selector: 'fws-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
})
export class GameComponent implements OnInit {
  @Input() game: Game;

  constructor() {}

  ngOnInit() {}

  public get isToday(): boolean {
    const today = new Date();
    const matchDate = new Date(this.game.matchDate.toString());
    if (
      matchDate.getDate() === today.getDate() &&
      matchDate.getMonth() === today.getMonth() &&
      matchDate.getFullYear() === today.getFullYear()
    ) {
      return true;
    }
    return false;
  }
}
