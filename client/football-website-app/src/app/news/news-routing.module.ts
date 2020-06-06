import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewsContainerComponent } from './news-container/news-container.component';
import { SharedModule } from '../shared/shared.module';

const routes: Routes = [{ path: '', component: NewsContainerComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NewsRoutingModule {}
