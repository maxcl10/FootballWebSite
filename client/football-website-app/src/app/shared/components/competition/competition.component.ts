import { Component, OnInit, Input } from '@angular/core';
import { Game } from '../../models/game.model';

@Component({
  selector: 'fws-competition',
  templateUrl: './competition.component.html',
  styleUrls: ['./competition.component.scss']
})
export class CompetitionComponent implements OnInit {
  @Input()
  game: Game;
  constructor() {}

  ngOnInit() {}
}
