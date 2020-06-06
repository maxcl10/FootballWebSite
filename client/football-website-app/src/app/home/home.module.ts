import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeContainerComponent } from './home-container/home-container.component';
import { SharedModule } from '../shared/shared.module';
import { LastNewsComponent } from './components/last-news/last-news.component';

@NgModule({
  declarations: [HomeContainerComponent, LastNewsComponent],
  imports: [CommonModule, HomeRoutingModule, SharedModule],
  exports: [SharedModule],
})
export class HomeModule {}
