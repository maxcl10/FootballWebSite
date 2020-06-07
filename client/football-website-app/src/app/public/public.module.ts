import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
// Modules

import { SharedModule } from '../shared/shared.module';

// Routing
import { PublicRoutingModule } from './public-routing.module';

// My components
import { TodayGameComponent } from './games/today-game/today-game.component';

import { SeasonSummaryComponent } from './stats/season-summary/season-summary.component';

import { GameDetailsComponent } from './games/game-details/game-details.component';
import { GamePosterComponent } from './games/game-poster/game-poster.component';
import { GamePosterGeneratorComponent } from './games/game-poster-generator/game-poster-generator.component';
import { PosterBaseComponent } from './games/poster-base/poster-base.component';

import { GameComponent } from './games/game/game.component';

@NgModule({
  declarations: [
    TodayGameComponent,
    SeasonSummaryComponent,
    GameDetailsComponent,
    GamePosterComponent,
    GamePosterGeneratorComponent,
    PosterBaseComponent,
    GameComponent,
  ],
  imports: [CommonModule, PublicRoutingModule, SharedModule],
  exports: [RouterModule],
})
export class PublicModule {}
