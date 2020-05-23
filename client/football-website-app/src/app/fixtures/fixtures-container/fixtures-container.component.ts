import {
  Component,
  OnInit,
  OnDestroy,
  AfterViewInit,
  ViewChild,
  ElementRef,
  AfterContentInit,
  AfterViewChecked,
} from '@angular/core';

import { groupBy, mergeMap, toArray } from 'rxjs/operators';
import { Observable, from, merge, of } from 'rxjs';
import { group } from '@angular/animations';
import { GamesService } from '../../core/services/games.service';
import { LogoService } from '../../core/services/logo.service';
import { TeamsService } from '../../core/services/teams.service';
import { Game } from '../../shared/models/game.model';
import { SeoService } from '../../core/services/seo.service';
import { AppConfig } from '../../app.config';
import { SubSink } from 'subsink';
import { RankingsService } from '../../ranking/rankings.service';
import { Competition } from '../../shared/models/competition.model';

@Component({
  selector: 'fws-fixtures-container',
  templateUrl: './fixtures-container.component.html',
})
export class FixturesContainerComponent
  implements OnInit, OnDestroy, AfterViewChecked {
  errorMessage: string;
  homeTeam: string;
  subs = new SubSink();

  scrolled = false;
  gamesPerMonth: Game[][];
  loading: boolean;
  currentMonth =
    new Date().getFullYear() +
    '-' +
    (new Date().getMonth() + 1).toString().padStart(2, '0');
  championshipData: Competition;

  constructor(
    private gamesService: GamesService,
    private teamsService: TeamsService,
    private logoService: LogoService,
    private seoService: SeoService,
    private rankingServce: RankingsService
  ) {}

  ngAfterViewChecked(): void {
    const element = document.querySelector('#heading' + this.currentMonth);

    if (element && !this.scrolled) {
      console.log('scroll: ' + element.id + ' height: ' + element.scrollTop);
      // window.scrollTo(0, element.scrollHeight);
      element.scrollIntoView({ behavior: 'smooth', block: 'start' });
      this.scrolled = true;
    }
  }

  public ngOnInit() {
    this.seoService.setTitle(
      AppConfig.settings.properties.siteName + ' - Calendrier'
    );
    this.loading = true;

    this.getGames();

    this.subs.sink = this.teamsService.getHomeTeams().subscribe(
      (homeTeams) => {
        this.homeTeam = homeTeams[0].name;
      },
      (error) => (this.errorMessage = <any>error)
    );

    this.subs.sink = this.rankingServce
      .getChampionshipData()
      .subscribe((res) => {
        this.championshipData = res;
      });
  }

  public getGames() {
    this.gamesPerMonth = new Array();

    this.subs.sink = this.gamesService.getGames().subscribe(
      (games) => {
        games.forEach((element) => {
          element.homeTeamLogoUrl = this.logoService.getLogoPath(
            element.homeTeam,
            60
          );
          element.awayTeamLogoUrl = this.logoService.getLogoPath(
            element.awayTeam,
            60
          );
        });

        from(games)
          .pipe(
            // Groups by date
            groupBy(
              (game) =>
                new Date(game.matchDate).getMonth() +
                '-' +
                new Date(game.matchDate).getFullYear()
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
    return game.matchDate.getMonth();
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
    this.scrolled = false;
  }
}
