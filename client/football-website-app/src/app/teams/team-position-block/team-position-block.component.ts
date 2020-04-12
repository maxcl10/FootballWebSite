import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../../shared/models/player.model';

@Component({
  selector: 'fws-team-position-block',
  templateUrl: './team-position-block.component.html',
  styleUrls: ['./team-position-block.component.css'],
})
export class TeamPositionBlockComponent implements OnInit {
  @Input() title: string;

  @Input() loading: boolean;
  @Input()
  players: Player[];

  constructor() {}

  ngOnInit(): void {}
}
