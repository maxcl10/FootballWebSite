import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'fws-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.scss']
})
export class WidgetComponent implements OnInit {
  constructor() {}

  @Input() headerText: string;

  @Input() contentMargin = true;

  @Input() loading = false;

  @Input() loadingText = 'Loading';

  @Input() error: string;

  ngOnInit() {}
}
