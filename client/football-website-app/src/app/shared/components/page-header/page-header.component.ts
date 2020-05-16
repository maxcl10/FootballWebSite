import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'fws-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css'],
})
export class PageHeaderComponent implements OnInit {
  @Input()
  white: boolean;

  constructor() {}

  ngOnInit(): void {}
}
