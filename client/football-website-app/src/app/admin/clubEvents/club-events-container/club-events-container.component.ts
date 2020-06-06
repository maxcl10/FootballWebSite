import { Component, OnInit } from '@angular/core';
import { ClubEventsService } from '../../../core/services/clubEvents.service';
import { ClubEvent } from '../../../shared/models/club-event.model';
import { Router } from '@angular/router';

@Component({
  selector: 'fws-club-events-container',
  templateUrl: './club-events-container.component.html',
  styleUrls: ['./club-events-container.component.css'],
})
export class ClubEventsContainerComponent implements OnInit {
  clubEvents: ClubEvent[];

  constructor(
    private clubEventService: ClubEventsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.clubEventService.getClubEvents().subscribe((res) => {
      this.clubEvents = res;
    });
  }

  public goToDetails(clubEvent: ClubEvent) {
    this.router.navigate(['admin/clubEvents', clubEvent.id, 'edit']);
  }
}
