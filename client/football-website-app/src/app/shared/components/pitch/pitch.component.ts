import { Component, OnInit, Input } from '@angular/core';
import { GamePlayer } from '../../models/game-player.model';

@Component({
  selector: 'fws-pitch',
  templateUrl: './pitch.component.html',
  styleUrls: ['./pitch.component.scss']
})
export class PitchComponent implements OnInit {
  @Input()
  players: GamePlayer[];

  constructor() {}

  ngOnInit() {}
}
