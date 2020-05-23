import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NewsRoutingModule } from './news-routing.module';
import { NewsContainerComponent } from './news-container/news-container.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [NewsContainerComponent],
  imports: [CommonModule, NewsRoutingModule, SharedModule],
})
export class NewsModule {}
