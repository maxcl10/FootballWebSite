import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { GameContainerComponent } from './game-container/game-container.component';

@NgModule({
  declarations: [GameContainerComponent],
  imports: [CommonModule, GamesRoutingModule],
})
export class GamesModule {}
