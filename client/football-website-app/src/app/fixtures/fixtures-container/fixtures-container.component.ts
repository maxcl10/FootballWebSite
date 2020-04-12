import { Component, OnInit } from '@angular/core';

import { groupBy, mergeMap, toArray } from 'rxjs/operators';
import { Observable, from, merge, of } from 'rxjs';
import { group } from '@angular/animations';
import { GamesService } from '../../core/services/games.service';
import { LogoService } from '../../core/services/logo.service';
import { TeamsService } from '../../core/services/teams.service';
import { Game } from '../../shared/models/game.model';
import { SeoService } from '../../core/services/seo.service';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-fixtures-container',
  templateUrl: './fixtures-container.component.html',
  providers: [GamesService, LogoService, TeamsService],
})
export class FixturesContainerComponent implements OnInit {
  errorMessage: string;
  homeTeam: string;
  gamesPerMonth: Game[][];
  loading: boolean;
  currentMonth =
    new Date().getFullYear() +
    '-' +
    (new Date().getMonth() + 1).toString().padStart(2, '0');

  constructor(
    private gamesService: GamesService,
    private teamsService: TeamsService,
    private logoService: LogoService,
    private seoService: SeoService
  ) {}

  public ngOnInit() {
    this.seoService.setTitle(
      AppConfig.settings.properties.siteName + ' - Calendrier'
    );
    this.loading = true;

    this.getGames();

    this.teamsService.getHomeTeams().subscribe(
      (homeTeams) => {
        this.homeTeam = homeTeams[0].name;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getGames() {
    this.gamesPerMonth = new Array();

    this.gamesService.getGames().subscribe(
      (games) => {
        games.forEach((element) => {
          element.homeTeamLogoUrl = this.logoService.getLogoPath(
            element.HomeTeam,
            60
          );
          element.awayTeamLogoUrl = this.logoService.getLogoPath(
            element.AwayTeam,
            60
          );
        });

        from(games)
          .pipe(
            // Groups by date
            groupBy(
              (game) =>
                new Date(game.MatchDate).getMonth() +
                '-' +
                new Date(game.MatchDate).getFullYear()
            ),
            // return each item in group as array
            mergeMap((grouped) => grouped.pipe(toArray()))
          )
          .subscribe((val) => {
            this.gamesPerMonth.push(val);
          });
        this.loading = false;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getWeb(game: Game) {
    return game.MatchDate.getMonth();
  }
}
