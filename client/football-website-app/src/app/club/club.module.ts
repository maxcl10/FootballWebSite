import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClubRoutingModule } from './club-routing.module';
import { HistoryContainerComponent } from './history-container/history-container.component';
import { OrganizationalChartContainerComponent } from './organizational-chart-container/organizational-chart-container.component';
import { SharedModule } from '../shared/shared.module';
import { EventsContainerComponent } from './events-container/events-container.component';
import { EventItemComponent } from './event-item/event-item.component';

@NgModule({
  declarations: [
    HistoryContainerComponent,
    OrganizationalChartContainerComponent,
    EventsContainerComponent,
    EventItemComponent,
  ],
  imports: [CommonModule, ClubRoutingModule, SharedModule],
})
export class ClubModule {}
