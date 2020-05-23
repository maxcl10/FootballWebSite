import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../../shared/models/article.model';

@Component({
  selector: 'fws-last-news',
  templateUrl: './last-news.component.html',
  styleUrls: ['./last-news.component.css'],
})
export class LastNewsComponent implements OnInit {
  @Input() articles: Article;

  constructor() {}

  ngOnInit(): void {}
}
