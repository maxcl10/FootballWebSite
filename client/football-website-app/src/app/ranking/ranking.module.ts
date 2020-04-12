import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RankingRoutingModule } from './ranking-routing.module';
import { RankingContainerComponent } from './ranking-container/ranking-container.component';
import { RankingTableComponent } from './ranking-table/ranking-table.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [RankingContainerComponent, RankingTableComponent],
  imports: [CommonModule, RankingRoutingModule, SharedModule],
})
export class RankingModule {}
