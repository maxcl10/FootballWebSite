import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationService } from './services/authentication.service';
import { CheckForUpdateService } from './services/check-for-update.service';
import { LogoService } from './services/logo.service';
import { SeoService } from './services/seo.service';
import { PromptUpdateService } from './services/prompt-update.service';
import { LogUpdateService } from './services/log-update.service';
import { GamesService } from './services/games.service';
import { ArticlesService } from './services/articles.service';
import { ClubService } from './services/club.service';
import { SponsorsService } from './services/sponsors.service';
import { StatsService } from './services/stats.service';
import { LeagueRankingsService } from './services/league-table.service';
import { TeamsService } from './services/teams.service';
import { CacheInterceptor } from './interceptors/cache-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { EventsService } from './services/events.service';

// This module contains all the services and all the top level app components
@NgModule({
  imports: [CommonModule],
  declarations: [],
  providers: [
    AuthenticationService,
    CheckForUpdateService,
    LogoService,
    SeoService,
    PromptUpdateService,
    LogUpdateService,
    GamesService,
    ArticlesService,
    ClubService,
    SponsorsService,
    StatsService,
    LeagueRankingsService,
    EventsService,
    TeamsService,
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true }
  ]
})
export class CoreModule {}
