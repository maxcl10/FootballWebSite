import { Component, OnInit } from '@angular/core';
import { ClubEventsService } from '../../core/services/clubEvents.service';
import { ClubEvent } from '../../shared/models/club-event.model';
import { map, flatMap, toArray } from 'rxjs/operators';

@Component({
  selector: 'fws-events-container',
  templateUrl: './events-container.component.html',
  styleUrls: ['./events-container.component.css'],
})
export class EventsContainerComponent implements OnInit {
  previousEvents: ClubEvent[];
  nextEvents: ClubEvent[];

  constructor(private clubEventsService: ClubEventsService) {}

  ngOnInit(): void {
    this.clubEventsService
      .getClubEvents()
      .pipe(
        flatMap((res) => res),
        map((item) => ({
          ...item,
          startDate: new Date(item.startDate),
        })),
        toArray()
      )
      .subscribe((events) => {
        this.previousEvents = events.filter((o) => o.startDate < new Date());
        this.nextEvents = events.filter((o) => o.startDate >= new Date());
      });

    // .pipe(
    //   map((data) => {
    //     return data.map((item: ClubEvent) => {
    //       item.startDate = new Date(item.startDate);
    //     });
    //   })
    // )
    // .subscribe((res: ClubEvent[]) => {
    //   this.clubEvents = res;
    //   this.nextEvent = res.filter(
    //     (o) => new Date(o.startDate) > new Date()
    //   )[0];
    // });
  }
}
