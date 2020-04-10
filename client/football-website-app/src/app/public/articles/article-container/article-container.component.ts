import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Article } from '../../../shared/models/article.model';
import { AuthenticationService } from '../../../core/services/authentication.service';
import { Title } from '@angular/platform-browser';
import { AppConfig } from '../../../app.config';
import { ArticlesService } from '../../../core/services/articles.service';

@Component({
  selector: 'fws-article-container',
  templateUrl: './article-container.component.html',
  providers: [AuthenticationService]
})
export class ArticleContainerComponent implements OnInit {
  public article: Article;
  public errorMessage: string;
  public isAuthenticated: boolean;
  private sub: any;
  public appUrl: string;

  constructor(
    private articleService: ArticlesService,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private titleService: Title
  ) {
    this.article = new Article();
    this.appUrl = AppConfig.settings.properties.siteUrl;
  }

  public ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      const id = params['id']; // (+) converts string 'id' to a number
      this.getArticle(id);
    });
    this.isAuthenticated = this.authenticationService.isLoggedIn();
  }

  public getArticle(id: string) {
    this.articleService.getArticle(id).subscribe(
      article => {
        this.article = article;
        this.titleService.setTitle(article.title);
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public goToEdit() {
    this.router.navigate(['/admin/articles', this.article.id, 'edit']);
  }

  public goToAdmin() {
    this.router.navigate(['/admin']);
  }

  public goBack() {
    window.history.back();
  }
}
