import { Component, OnInit, OnDestroy } from '@angular/core';

import { Title } from '@angular/platform-browser';

import { RankingsService } from '../rankings.service';
import { Competition } from '../../shared/models/competition.model';
import { AppConfig } from '../../app.config';
import { SubSink } from 'subsink';
import { LogoService } from '../../core/services/logo.service';
import { TeamsService } from '../../core/services/teams.service';
import { Ranking } from '../../shared/models/league-table.model';

@Component({
  selector: 'fws-ranking-container',
  templateUrl: './ranking-container.component.html',
})
export class RankingContainerComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  loading: boolean;

  competition: Competition;
  homeTeam: string;
  errorMessage: string;
  ranking: Ranking[];

  constructor(
    private titleService: Title,
    private rankingService: RankingsService,
    private logoService: LogoService,
    private teamsService: TeamsService
  ) {}

  public ngOnInit() {
    this.loading = true;
    // Get championship info in order to display the title
    this.subs.sink = this.rankingService
      .getChampionshipData()
      .subscribe((result) => {
        this.competition = result;
      });

    // Set the page title
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Classement'
    );

    // Get the home team
    this.teamsService.getHomeTeams().subscribe(
      (homeTeams) => {
        this.homeTeam = homeTeams[0].name;
      },
      (error) => (this.errorMessage = <any>error)
    );

    this.getRankings();
  }

  public getRankings() {
    this.subs.sink = this.rankingService.getRankings().subscribe(
      (ranking) => {
        ranking.forEach((element) => {
          element.imageUrl = this.logoService.getLogoPath(element.team, 30);
        });
        this.ranking = ranking;
        this.loading = false;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
