import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../shared/models/article.model';
import { Game } from '../../shared/models/game.model';

@Component({
  selector: 'fws-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.scss'],
})
export class ArticleDetailsComponent implements OnInit {
  constructor() {}

  @Input()
  public article: Article;

  @Input()
  public game: Game;

  ngOnInit() {}
}
