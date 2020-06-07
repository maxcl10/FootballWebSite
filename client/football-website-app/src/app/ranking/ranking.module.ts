import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RankingRoutingModule } from './ranking-routing.module';
import { RankingContainerComponent } from './ranking-container/ranking-container.component';
import { RankingTableComponent } from './ranking-table/ranking-table.component';
import { SharedModule } from '../shared/shared.module';
import { RankingTableSmallComponent } from './ranking-table-small/ranking-table-small.component';

@NgModule({
  declarations: [
    RankingContainerComponent,
    RankingTableComponent,
    RankingTableSmallComponent,
  ],
  imports: [CommonModule, RankingRoutingModule, SharedModule],
  exports: [SharedModule],
})
export class RankingModule {}
