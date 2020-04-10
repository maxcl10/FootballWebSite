import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../../shared/models/article.model';

@Component({
  selector: 'fws-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  constructor() {}

  @Input()
  public article: Article;

  ngOnInit() {}
}
