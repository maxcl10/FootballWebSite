import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../models/game.model';

@Component({
  selector: 'fws-game-score',
  templateUrl: './game-score.component.html',
  styleUrls: ['./game-score.component.scss']
})
export class GameScoreComponent implements OnInit {
  @Input() game: Game;

  constructor() {}

  ngOnInit() {}
}
