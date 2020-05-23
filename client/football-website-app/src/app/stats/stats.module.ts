import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatsRoutingModule } from './stats-routing.module';
import { StatsContainerComponent } from './stats-container/stats-container.component';
import { StatsAssistsComponent } from './stats-assists/stats-assists.component';
import { StatsStrickersComponent } from './stats-strickers/stats-strickers.component';
import { StatsLastResultsComponent } from './stats-last-results/stats-last-results.component';
import { StatsPieChartComponent } from './stats-pie-chart/stats-pie-chart.component';
import { SharedModule } from '../shared/shared.module';
import { ChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    StatsContainerComponent,
    StatsAssistsComponent,
    StatsStrickersComponent,
    StatsLastResultsComponent,
    StatsPieChartComponent,
  ],
  imports: [CommonModule, StatsRoutingModule, ChartsModule, SharedModule],
})
export class StatsModule {}
