import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';

import { LeagueRankingsService } from '../../../core/services/league-table.service';
import { LogoService } from '../../../core/services/logo.service';
import { TeamsService } from '../../../core/services/teams.service';
import { Subscription } from 'rxjs';
import { Ranking } from '../../../shared/models/league-table.model';

@Component({
  selector: 'fws-league-table',
  templateUrl: './league-table.component.html',
  providers: [LeagueRankingsService, LogoService, TeamsService]
})
export class LeagueTableComponent implements OnInit, OnDestroy {
  public rankings: Ranking[];
  public errorMessage: string;
  public homeTeam: string;
  private subscription: Subscription;

  constructor(
    private rankingService: LeagueRankingsService,
    private logoService: LogoService,
    private teamsService: TeamsService
  ) {}

  public ngOnInit() {
    this.teamsService.getHomeTeams().subscribe(
      homeTeams => {
        this.homeTeam = homeTeams[0].name;
      },
      error => (this.errorMessage = <any>error)
    );

    this.getRankings();
  }

  public getRankings() {
    this.subscription = this.rankingService.getRankings().subscribe(
      rankings => {
        rankings.forEach(element => {
          element.imageUrl = this.logoService.getLogoPath(element.team, 30);
        });
        this.rankings = rankings;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
