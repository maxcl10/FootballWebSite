import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

// Modules

import { SharedModule } from '../shared/shared.module';

// Routing
import { PublicRoutingModule } from './public-routing.module';

// My components
import { HomeComponent } from './home/home/home.component';
import { HistoryComponent } from './club/history/history.component';
import { ArticleComponent } from './articles/article/article.component';
import { GamesComponent } from './games/games-list/games-list.component';
import { TodayGameComponent } from './games/today-game/today-game.component';
import { ContactComponent } from './club/contact/contact.component';

import { RankingHistoryComponent } from './stats/ranking-History-chart/ranking-history-chart.component';
import { SeasonSummaryComponent } from './stats/season-summary/season-summary.component';
import { OrganizationalChartComponent } from './club/organizational-chart/organizational-chart.component';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { GameDetailsComponent } from './games/game-details/game-details.component';
import { GamePosterComponent } from './games/game-poster/game-poster.component';
import { GamePosterGeneratorComponent } from './games/game-poster-generator/game-poster-generator.component';
import { PosterBaseComponent } from './games/poster-base/poster-base.component';
import { ArticleContainerComponent } from './articles/article-container/article-container.component';
import { GameComponent } from './games/game/game.component';

@NgModule({
  declarations: [
    HomeComponent,

    HistoryComponent,
    ArticleComponent,
    ContactComponent,
    GamesComponent,
    TodayGameComponent,
    RankingHistoryComponent,
    SeasonSummaryComponent,
    OrganizationalChartComponent,
    LoginComponent,
    GameDetailsComponent,
    GamePosterComponent,
    GamePosterGeneratorComponent,
    PosterBaseComponent,
    ArticleContainerComponent,
    GameComponent,
  ],
  imports: [SharedModule, CommonModule, PublicRoutingModule],
  exports: [RouterModule],
})
export class PublicModule {}
