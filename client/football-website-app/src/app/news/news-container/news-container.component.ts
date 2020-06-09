import { Component, OnInit } from '@angular/core';
import { ArticlesService } from '../../core/services/articles.service';
import { Article } from '../../shared/models/article.model';
import { Title } from '@angular/platform-browser';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-news-container',
  templateUrl: './news-container.component.html',
  styleUrls: ['./news-container.component.css'],
})
export class NewsContainerComponent implements OnInit {
  articles: Article[];
  constructor(
    private articlesService: ArticlesService,
    private titleService: Title
  ) {}

  ngOnInit(): void {
    this.articlesService.getArticles().subscribe((res) => {
      this.articles = res;
    });

    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Actualités'
    );
  }
}
