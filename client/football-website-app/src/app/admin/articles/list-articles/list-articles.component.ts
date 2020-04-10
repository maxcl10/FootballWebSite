import { Component, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { ArticlesService } from '../../../core/services/articles.service';
import { Article } from '../../../shared/models/article.model';
import { Router } from '@angular/router';

@Component({
  selector: 'fws-list-articles',
  templateUrl: './list-articles.component.html',
  styleUrls: ['./list-articles.component.scss']
})
export class ListArticlesComponent implements OnInit {
  public articles$: Observable<Article[]>;
  @Output()
  public selectedArticle: Article;

  constructor(
    private articlesService: ArticlesService,
    private router: Router
  ) {}

  ngOnInit() {
    this.articles$ = this.articlesService.getArticles();
  }

  public onselect(article: Article) {
    this.selectedArticle = article;
    this.goToDetails(this.selectedArticle);
  }

  public goToDetails(article: Article) {
    this.router.navigate(['admin/articles', article.id, 'edit']);
  }
}
