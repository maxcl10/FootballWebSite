import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SponsorsRoutingModule } from './sponsors-routing.module';
import { SponsorsContainerComponent } from './sponsors-container/sponsors-container.component';


@NgModule({
  declarations: [SponsorsContainerComponent],
  imports: [
    CommonModule,
    SponsorsRoutingModule
  ]
})
export class SponsorsModule { }
