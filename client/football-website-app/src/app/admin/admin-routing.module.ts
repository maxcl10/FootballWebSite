import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { EditGameComponent } from './games/edit-game/edit-game.component';
import { EditPlayerStatsComponent } from './players/edit-player-stats/edit-player-stats.component';
import { EditArticleComponent } from './articles/edit-article/edit-article.component';
import { EditPlayerComponent } from './players/edit-player/edit-player.component';
import { UploadRankingComponent } from './upload-ranking/upload-ranking.component';
import { ListArticlesComponent } from './articles/list-articles/list-articles.component';
import { ListPlayersComponent } from './players/list-players/list-players.component';
import { EditTeamComponent } from './teams/edit-team/edit-team.component';
import { ListGamesComponent } from './games/list-games/list-games.component';
import { PlayerStatsListComponent } from './players/player-stats-list/player-stats-list.component';
import { EditSponsorComponent } from './sponsors/edit-sponsor/edit-sponsor.component';
import { ListSponsorsComponent } from './sponsors/list-sponsors/list-sponsors.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ClubsListComponent } from './clubs/clubs-list/clubs-list.component';
import { EditClubComponent } from './clubs/edit-club/edit-club.component';
import { EditGamePlayersComponent } from './games/edit-game-players/edit-game-players.component';
import { TeamsContainerComponent } from './teams/teams-container/teams-container.component';
import { ClubEventsContainerComponent } from './clubEvents/club-events-container/club-events-container.component';
import { EditClubEventContainerComponent } from './clubEvents/edit-club-event-container/edit-club-event-container.component';
import { GamePosterComponent } from './posters/game-poster/game-poster.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        component: DashboardComponent,
      },
      {
        path: 'articles',
        component: ListArticlesComponent,
      },
      {
        path: 'articles/:id/edit',
        component: EditArticleComponent,
      },
      {
        path: 'games',
        component: ListGamesComponent,
      },
      {
        path: 'posters',
        component: GamePosterComponent,
      },
      {
        path: 'games/:id/edit',
        component: EditGameComponent,
      },
      {
        path: 'games/:id/players',
        component: EditGamePlayersComponent,
      },
      {
        path: 'players',
        component: ListPlayersComponent,
      },
      {
        path: 'players/:id/edit',
        component: EditPlayerComponent,
      },
      {
        path: 'players/:id/editstats',
        component: EditPlayerStatsComponent,
      },
      {
        path: 'players/stats',
        component: PlayerStatsListComponent,
      },
      {
        path: 'teams',
        component: TeamsContainerComponent,
      },
      {
        path: 'teams/:id/edit',
        component: EditTeamComponent,
      },
      {
        path: 'clubs',
        component: ClubsListComponent,
      },
      {
        path: 'clubs/:id/edit',
        component: EditClubComponent,
      },
      {
        path: 'clubEvents',
        component: ClubEventsContainerComponent,
      },
      {
        path: 'clubEvents/:id/edit',
        component: EditClubEventContainerComponent,
      },
      {
        path: 'ranking',
        component: UploadRankingComponent,
      },
      {
        path: 'sponsors',
        component: ListSponsorsComponent,
      },
      {
        path: 'sponsors/:id/edit',
        component: EditSponsorComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
