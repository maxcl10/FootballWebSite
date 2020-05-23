import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { GameContainerComponent } from './game-container/game-container.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [GameContainerComponent],
  imports: [CommonModule, GamesRoutingModule, SharedModule],
})
export class GamesModule {}
