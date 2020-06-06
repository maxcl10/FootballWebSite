import { Component, OnInit, Input } from '@angular/core';
import { ClubEvent } from '../../shared/models/club-event.model';

@Component({
  selector: 'fws-event-item',
  templateUrl: './event-item.component.html',
  styleUrls: ['./event-item.component.css'],
})
export class EventItemComponent implements OnInit {
  @Input() event: ClubEvent;

  today = new Date();

  constructor() {}

  ngOnInit(): void {}
}
