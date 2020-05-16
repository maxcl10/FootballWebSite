import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../models/game.model';

@Component({
  selector: 'fws-game-widget',
  templateUrl: './game-widget.component.html',
  styleUrls: ['./game-widget.component.css'],
})
export class GameWidgetComponent implements OnInit {
  constructor() {}

  @Input()
  game: Game;

  ngOnInit(): void {}
}
