import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SponsorsRoutingModule } from './sponsors-routing.module';
import { SponsorsContainerComponent } from './sponsors-container/sponsors-container.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [SponsorsContainerComponent],
  imports: [CommonModule, SponsorsRoutingModule, SharedModule],
})
export class SponsorsModule {}
