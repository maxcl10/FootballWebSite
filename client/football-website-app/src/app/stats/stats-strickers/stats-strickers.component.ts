import { Component, OnInit, Input } from '@angular/core';
import { Stricker } from '../../shared/models/stricker.model';
import { StatsService } from '../../core/services/stats.service';

@Component({
  selector: 'fws-stats-strickers',
  templateUrl: './stats-strickers.component.html',
  styleUrls: ['./stats-strickers.component.css'],
})
export class StatsStrickersComponent {
  private _strickers: Stricker[];

  public totalGoals = 0;
  public totalChampionshipGoals = 0;
  public totalNationalCupGoals = 0;
  public totalRegionalCupGoals = 0;
  public totalOtherCupGoals = 0;

  @Input()
  set playerStats(playerStats: Stricker[]) {
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

  get strickers(): Stricker[] {
    return this._strickers;
  }
}