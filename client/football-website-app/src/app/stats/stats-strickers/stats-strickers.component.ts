import { Component, OnInit, Input } from '@angular/core';
import { PlayerStats } from '../../shared/models/stricker.model';

@Component({
  selector: 'fws-stats-strickers',
  templateUrl: './stats-strickers.component.html',
  styleUrls: ['./stats-strickers.component.css'],
})
export class StatsStrickersComponent {
  private _strickers: PlayerStats[];

  public totalGoals = 0;
  public totalChampionshipGoals = 0;
  public totalNationalCupGoals = 0;
  public totalRegionalCupGoals = 0;
  public totalOtherCupGoals = 0;

  @Input()
  set playerStats(playerStats: PlayerStats[]) {
    if (playerStats) {
      this._strickers = playerStats.filter((o) => o.totalGoals > 0);

      this.strickers.forEach((element) => {
        this.totalGoals += element.totalGoals;
        this.totalChampionshipGoals += element.championshipGoals;
        this.totalNationalCupGoals += element.nationalCupGoals;
        this.totalRegionalCupGoals += element.regionalCupGoals;
        this.totalOtherCupGoals += element.otherCupGoals;
      });
    }
  }

  get strickers(): PlayerStats[] {
    return this._strickers;
  }
}
