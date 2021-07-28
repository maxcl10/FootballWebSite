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

import { GameComponent } from './games/game/game.component';

@NgModule({
  declarations: [
    TodayGameComponent,
    SeasonSummaryComponent,
    GameDetailsComponent,
    GameComponent,
  ],
  imports: [CommonModule, PublicRoutingModule, SharedModule],
  exports: [RouterModule],
})
export class PublicModule {}
