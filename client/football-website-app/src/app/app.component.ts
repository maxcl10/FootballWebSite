/*
 * Angular 2 decorators and services
 */

import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AppState } from './app.service';
import { Router, Event, NavigationEnd } from '@angular/router';
import { fadeAnimation } from './shared/animations/animation';

import { TeamsService } from './core/services/teams.service';
import { Team } from './shared/models/team.model';
import { AppConfig } from './app.config';

import * as jQuery from 'jquery';

import { ClubService } from './core/services/club.service';
import { Club } from './shared/models/club.model';
declare let ga: any;

/*
 * App Component
 * Top Level Component
 */
@Component({
  selector: 'fws-root',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './app.component.html',
  providers: [TeamsService, AppConfig, ClubService],
  animations: [fadeAnimation]
})
export class AppComponent implements OnInit {
  public teams: Team[];
  public club: Club;
  public errorMessage: string;

  constructor(
    public appState: AppState,
    private teamsService: TeamsService,
    private clubService: ClubService,
    public router: Router
  ) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        // comment has been removed
        ga('send', 'pageview', event.urlAfterRedirects);
      }
      window.scrollTo(0, 0);
    });

    // Method to close the nav bar when clicking on a link on small screens
    $(document).on('click', '.navbar-collapse.in', function(e) {
      if (
        $(e.target).is('a') &&
        $(e.target).attr('class') !== 'dropdown-toggle'
      ) {
        $(this).collapse('hide');
      }
    });
  }

  public ngOnInit() {
    console.log('Initial App State', this.appState.state);

    this.teamsService.getHomeTeams().subscribe(
      homeTeams => {
        this.teams = homeTeams;
      },
      error => (this.errorMessage = <any>error)
    );

    this.clubService.getClub().subscribe(
      club => {
        this.club = club;
      },
      error => (this.errorMessage = <any>error)
    );
  }
}
