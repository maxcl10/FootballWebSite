import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StatsContainerComponent } from './stats-container/stats-container.component';

const routes: Routes = [
  {
    path: '',
    component: StatsContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StatsRoutingModule {}
