import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { Article } from '../../../shared/models/article.model';
import { ArticlesService } from '../../../core/services/articles.service';

import { AppConfig } from '../../../app.config';
import { GamesService } from '../../../core/services/games.service';
import { Game } from '../../../shared/models/game.model';
import { LogoService } from '../../../core/services/logo.service';

@Component({
  selector: 'fws-home',
  templateUrl: './home.component.html',
  providers: [ArticlesService]
})
export class HomeComponent implements OnInit {
  public articles: Article[];
  public nextGame: Game;
  public lastGame: Game;
  public loaded = false;
  public errorMessage: string;
  public imageUrls: string[];

  constructor(
    private articlesService: ArticlesService,
    private gamesService: GamesService,
    private titleService: Title,
    private logoService: LogoService
  ) {}

  public getArticles() {
    this.articlesService.getArticles().subscribe(
      articles => {
        this.articles = articles.filter(o => o.published);
        this.loaded = true;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Site officiel'
    );
    this.imageUrls = AppConfig.settings.properties.homeImageUrls;

    this.getArticles();
    this.getNextGame();
    this.getLastGame();
  }

  public getLastGame() {
    this.gamesService.getLastGame().subscribe(
      game => {
        this.lastGame = game;
        this.lastGame.awayTeamLogoUrl = this.logoService.getLogoPath(
          this.lastGame.AwayTeam,
          60
        );
        this.lastGame.homeTeamLogoUrl = this.logoService.getLogoPath(
          this.lastGame.HomeTeam,
          60
        );
      },
      error => (this.errorMessage = <any>error)
    );
  }

  private getNextGame() {
    this.gamesService.getNextGame().subscribe(
      game => {
        this.nextGame = game;
        if (this.nextGame != null) {
          this.nextGame.awayTeamLogoUrl = this.logoService.getLogoPath(
            this.nextGame.AwayTeam,
            60
          );
          this.nextGame.homeTeamLogoUrl = this.logoService.getLogoPath(
            this.nextGame.HomeTeam,
            60
          );
        }
      },
      error => (this.errorMessage = <any>error)
    );
  }
}
