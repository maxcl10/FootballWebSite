/*
 * Angular 2 decorators and services
 */

import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AppState } from './app.service';
import { Router, Event, NavigationEnd } from '@angular/router';
import { fadeAnimation } from './shared/animations/animation';

declare let ga: any;

/*
 * App Component
 * Top Level Component
 */
@Component({
  selector: 'fws-root',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './app.component.html',
  animations: [fadeAnimation],
})
export class AppComponent implements OnInit {
  public errorMessage: string;

  constructor(public appState: AppState, public router: Router) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        // comment has been removed

        ga('send', 'pageview', event.urlAfterRedirects);
      }
    });
  }

  public ngOnInit() {}
}
