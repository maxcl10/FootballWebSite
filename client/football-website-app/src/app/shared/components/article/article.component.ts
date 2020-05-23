import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../models/article.model';

@Component({
  selector: 'fws-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css'],
})
export class ArticleComponent implements OnInit {
  @Input() article: Article;

  constructor() {}

  ngOnInit(): void {}
}
