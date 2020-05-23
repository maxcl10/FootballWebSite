import { Component, OnInit, Input } from '@angular/core';
import { Event } from '../../models/event.model';

@Component({
  selector: 'fws-event-type',
  templateUrl: './event-type.component.html',
  styleUrls: ['./event-type.component.css'],
})
export class EventTypeComponent implements OnInit {
  @Input()
  event: Event;

  constructor() {}

  ngOnInit(): void {}
}
