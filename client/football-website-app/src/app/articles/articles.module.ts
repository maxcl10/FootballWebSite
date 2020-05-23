import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticleContainerComponent } from './article-container/article-container.component';
import { SharedModule } from '../shared/shared.module';
import { ArticleDetailsComponent } from './article-details/article-details.component';

@NgModule({
  declarations: [ArticleContainerComponent, ArticleDetailsComponent],
  imports: [CommonModule, ArticlesRoutingModule, SharedModule],
})
export class ArticlesModule {}
