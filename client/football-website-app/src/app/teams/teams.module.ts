import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeamsRoutingModule } from './teams-routing.module';
import { TeamContainerComponent } from './team-container/team-container.component';
import { SharedModule } from '../shared/shared.module';
import { TeamPositionBlockComponent } from './team-position-block/team-position-block.component';

@NgModule({
  declarations: [TeamContainerComponent, TeamPositionBlockComponent],
  imports: [CommonModule, TeamsRoutingModule, SharedModule],
})
export class TeamsModule {}
