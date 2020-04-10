import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// My components
import { HomeComponent } from './home/home/home.component';
import { TeamComponent } from './teams/team/team.component';
import { HistoryComponent } from './club/history/history.component';
import { PlayerComponent } from './players/player/player.component';
import { ContactComponent } from './club/contact/contact.component';
import { SponsorComponent } from './sponsors/sponsor/sponsor.component';
import { GamesComponent } from './games/games-list/games-list.component';

import { LoginComponent } from './login/login.component';
import { OrganizationalChartComponent } from './club/organizational-chart/organizational-chart.component';
import { GameDetailsComponent } from './games/game-details/game-details.component';
import { GamePosterComponent } from './games/game-poster/game-poster.component';
import { ArticleContainerComponent } from './articles/article-container/article-container.component';
import { LeagueTableContainerComponent } from './league-table/league-table-container/league-table-container.component';
import { StatsContainerComponent } from './stats/stats-container/stats-container.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'home',
    component: HomeComponent,
    data: {
      breadcrumb: 'Home'
    }
  },
  {
    path: 'team/:id',
    component: TeamComponent,
    data: {
      breadcrumb: 'Home'
    }
  },
  {
    path: 'club/history',
    component: HistoryComponent
  },
  {
    path: 'club/organizational-chart',
    component: OrganizationalChartComponent
  },

  {
    path: 'article/:id',
    component: ArticleContainerComponent
  },

  {
    path: 'player/:id',
    component: PlayerComponent
  },
  {
    path: 'contact',
    component: ContactComponent
  },
  {
    path: 'sponsors',
    component: SponsorComponent
  },
  {
    path: 'games',
    component: GamesComponent
  },
  {
    path: 'poster',
    component: GamePosterComponent
  },
  {
    path: 'game/:id',
    component: GameDetailsComponent
  },
  {
    path: 'league-table',
    component: LeagueTableContainerComponent
  },

  {
    path: 'stats',
    component: StatsContainerComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '**',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
