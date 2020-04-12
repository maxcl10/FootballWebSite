import { Component, OnInit } from '@angular/core';
import { RankingsService } from '../../../ranking/rankings.service';
import { TeamsService } from '../../../core/services/teams.service';
import { Ranking } from '../../../shared/models/league-table.model';

@Component({
  selector: 'fws-season-summary',
  templateUrl: './season-summary.component.html',
  styleUrls: ['./season-summary.component.scss'],
})
export class SeasonSummaryComponent implements OnInit {
  private homeTeam: string;
  private errorMessage: string;

  teamStat: Ranking;

  constructor(
    private rankingService: RankingsService,
    private teamsService: TeamsService
  ) {}

  ngOnInit() {
    this.teamsService.getHomeTeams().subscribe(
      (homeTeams) => {
        this.homeTeam = homeTeams[0].name;
        this.getRankings();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getRankings() {
    this.rankingService.getRankings().subscribe(
      (ranking) => {
        this.teamStat = ranking.find((o) => o.team === this.homeTeam);
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
