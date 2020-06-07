import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlayersRoutingModule } from './players-routing.module';

import { SharedModule } from '../shared/shared.module';
import { PlayerContainerComponent } from './player-container/player-container.component';
import { PlayerDetailsSmallComponent } from './player-details-small/player-details-small.component';
import { PlayersCarouselComponent } from './players-carousel/players-carousel.component';

@NgModule({
  declarations: [
    PlayerContainerComponent,
    PlayerDetailsSmallComponent,
    PlayersCarouselComponent,
  ],
  imports: [CommonModule, PlayersRoutingModule, SharedModule],
})
export class PlayersModule {}
