import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeContainerComponent } from './home-container/home-container.component';
import { SharedModule } from '../shared/shared.module';
import { GamesModule } from '../games/games.module';

@NgModule({
  declarations: [HomeContainerComponent],
  imports: [CommonModule, HomeRoutingModule, SharedModule, GamesModule],
})
export class HomeModule {}
