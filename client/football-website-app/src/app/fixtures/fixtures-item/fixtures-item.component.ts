import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../shared/models/game.model';

@Component({
  selector: 'fws-fixtures-item',
  templateUrl: './fixtures-item.component.html',
  styleUrls: ['./fixtures-item.component.scss'],
})
export class FixturesItemComponent implements OnInit {
  @Input() game: Game;

  constructor() {}

  ngOnInit() {}

  // todo: move in service
  public get isToday(): boolean {
    const today = new Date();
    const matchDate = new Date(this.game.MatchDate.toString());
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
