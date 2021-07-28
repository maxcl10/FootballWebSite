import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'fws-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.scss'],
  host: { class: 'w-100' },
})
export class WidgetComponent implements OnInit {
  constructor() {}

  @Input() headerText: string;

  @Input() contentMargin = true;

  @Input() loading = false;

  @Input() loadingText = 'Chargement';

  @Input() transparent = false;

  @Input() error: string;

  ngOnInit() {}
}
