import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RankingContainerComponent } from './ranking-container/ranking-container.component';

const routes: Routes = [
  {
    path: '',
    component: RankingContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RankingRoutingModule {}
