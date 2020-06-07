import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../../models/player.model';

@Component({
  selector: 'fws-player-picture',
  templateUrl: './player-picture.component.html',
  styleUrls: ['./player-picture.component.css'],
})
export class PlayerPictureComponent implements OnInit {
  @Input()
  player: Player;
  constructor() {}

  ngOnInit(): void {}
}
