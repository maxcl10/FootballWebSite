import { Component, OnInit } from '@angular/core';
import { Player } from '../../shared/models/player.model';
import { PlayersService } from '../../core/services/players.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../core/services/authentication.service';
import { SeoService } from '../../core/services/seo.service';
import { AppConfig } from '../../app.config';
import { ArticlesService } from '../../core/services/articles.service';
import { Article } from '../../shared/models/article.model';
import { SubSink } from 'subsink';
import { GamesService } from '../../core/services/games.service';
import { Game } from '../../shared/models/game.model';

@Component({
  selector: 'fws-article-container',
  templateUrl: './article-container.component.html',
  styleUrls: ['./article-container.component.css'],
})
export class ArticleContainerComponent implements OnInit {
  private sub = new SubSink();

  article: Article;
  errorMessage: string;

  isAuthenticated: boolean;
  game: Game;

  constructor(
    private articleService: ArticlesService,
    private gameService: GamesService,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private seoService: SeoService
  ) {}

  public ngOnInit() {
    this.sub.sink = this.route.params.subscribe((params) => {
      const id = params['id'];
      this.getArticle(id);
    });
    this.isAuthenticated = this.authenticationService.isLoggedIn();
  }

  public getArticle(id: string) {
    this.articleService.getArticle(id).subscribe(
      (player) => {
        this.article = player;

        this.seoService.setTitle(
          AppConfig.settings.properties.siteName + ' - ' + this.article.title
        );

        if (this.article.gameId) {
          this.gameService.getGame(this.article.gameId).subscribe((res) => {
            this.game = res;
          });
        }
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public goToEdit() {
    this.router.navigate(['admin/article', this.article.id, 'edit']);
  }

  public goBack() {
    window.history.back();
  }
}
