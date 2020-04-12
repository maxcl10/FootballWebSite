import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FixturesRoutingModule } from './fixtures-routing.module';
import { FixturesContainerComponent } from './fixtures-container/fixtures-container.component';
import { FixturesItemComponent } from './fixtures-item/fixtures-item.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [FixturesContainerComponent, FixturesItemComponent],
  imports: [CommonModule, FixturesRoutingModule, SharedModule],
})
export class FixturesModule {}
