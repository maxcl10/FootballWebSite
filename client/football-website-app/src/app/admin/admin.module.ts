import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

// Shared
import { SharedModule } from '../shared/shared.module';

// Externals
import { EditorModule } from '@tinymce/tinymce-angular';

// Routing
import { AdminRoutingModule } from './admin-routing.module';

// Module components
import { UploadRankingComponent } from './upload-ranking/upload-ranking.component';
import { EditTeamComponent } from './teams/edit-team/edit-team.component';
import { AdminComponent } from './admin/admin.component';
import { EditArticleComponent } from './articles/edit-article/edit-article.component';
import { PlayerStatsListComponent } from './players/player-stats-list/player-stats-list.component';
import { EditSponsorComponent } from './sponsors/edit-sponsor/edit-sponsor.component';
import { EditGameComponent } from './games/edit-game/edit-game.component';
import { EditPlayerStatsComponent } from './players/edit-player-stats/edit-player-stats.component';
import { EditPlayerComponent } from './players/edit-player/edit-player.component';
import { ListArticlesComponent } from './articles/list-articles/list-articles.component';
import { ListPlayersComponent } from './players/list-players/list-players.component';
import { ListGamesComponent } from './games/list-games/list-games.component';
import { ListSponsorsComponent } from './sponsors/list-sponsors/list-sponsors.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { ClubsListComponent } from './clubs/clubs-list/clubs-list.component';
import { EditClubComponent } from './clubs/edit-club/edit-club.component';
import { EditGamePlayersComponent } from './games/edit-game-players/edit-game-players.component';

@NgModule({
  imports: [
    SharedModule,
    FormsModule,
    EditorModule,
    AdminRoutingModule,
    CommonModule
  ],
  declarations: [
    UploadRankingComponent,
    EditTeamComponent,
    AdminComponent,
    PlayerStatsListComponent,
    EditSponsorComponent,
    EditArticleComponent,
    EditGameComponent,
    EditPlayerStatsComponent,
    EditPlayerComponent,
    ListArticlesComponent,
    ListPlayersComponent,
    ListGamesComponent,
    ListSponsorsComponent,
    DashboardComponent,
    ClubsListComponent,
    EditClubComponent,
    EditGamePlayersComponent
  ],
  exports: [RouterModule]
})
export class AdminModule {}
