import { Component, OnInit, Input } from '@angular/core';
import { Stricker } from '../../shared/models/stricker.model';

@Component({
  selector: 'fws-stats-assists',
  templateUrl: './stats-assists.component.html',
  styleUrls: ['./stats-assists.component.css'],
})
export class StatsAssistsComponent {
  private _assists: Stricker[];

  @Input()
  set playerStats(playerStats: Stricker[]) {
    if (playerStats) {
      this._assists = playerStats
        .filter((o) => o.totalAssists > 0)
        .sort((n1, n2) => n2.championshipAssists - n1.championshipAssists);
    }
  }

  get assists(): Stricker[] {
    return this._assists;
  }
}
