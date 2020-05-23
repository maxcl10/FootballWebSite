import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'fws-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css'],
})
export class PageHeaderComponent implements OnInit {
  @Input()
  hideBackButton;

  constructor() {}

  ngOnInit(): void {}

  public goBack() {
    window.history.back();
  }
}
