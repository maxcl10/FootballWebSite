import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../models/game.model';

@Component({
  selector: 'fws-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
})
export class GameComponent implements OnInit {
  @Input() game: Game;
  @Input() homeTeam: string;

  constructor() {}

  ngOnInit() {}
}
