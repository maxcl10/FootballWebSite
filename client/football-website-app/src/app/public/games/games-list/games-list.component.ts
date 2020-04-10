import { Component, OnInit } from '@angular/core';

import { GamesService } from '../../../core/services/games.service';
import { Game } from '../../../shared/models/game.model';
import { LogoService } from '../../../core/services/logo.service';
import { SeoService } from '../../../core/services/seo.service';
import { TeamsService } from '../../../core/services/teams.service';
import { AppConfig } from '../../../app.config';

import {
  groupBy,
  mergeMap,
  toArray,
  flatMap,
  map,
  switchMap
} from 'rxjs/operators';
import { Observable, from, merge, of } from 'rxjs';
import { group } from '@angular/animations';

@Component({
  selector: 'fws-games-list',
  templateUrl: './games-list.component.html',
  providers: [GamesService, LogoService, TeamsService]
})
export class GamesComponent implements OnInit {
  public errorMessage: string;
  public homeTeam: string;
  public gamesPerMonth: Game[][];
  public currentMonth =
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
    this.getGames();

    this.teamsService.getHomeTeams().subscribe(
      homeTeams => {
        this.homeTeam = homeTeams[0].name;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public getGames() {
    this.gamesPerMonth = new Array();

    this.gamesService.getGames().subscribe(
      games => {
        games.forEach(element => {
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
              game =>
                new Date(game.MatchDate).getMonth() +
                '-' +
                new Date(game.MatchDate).getFullYear()
            ),
            // return each item in group as array
            mergeMap(grouped => grouped.pipe(toArray()))
          )
          .subscribe(val => {
            this.gamesPerMonth.push(val);
          });
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public getWeb(game: Game) {
    return game.MatchDate.getMonth();
  }
}
