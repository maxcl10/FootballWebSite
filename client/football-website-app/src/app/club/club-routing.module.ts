import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryContainerComponent } from './history-container/history-container.component';
import { OrganizationalChartContainerComponent } from './organizational-chart-container/organizational-chart-container.component';

const routes: Routes = [
  { path: 'history', component: HistoryContainerComponent },
  {
    path: 'organizational-chart',
    component: OrganizationalChartContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClubRoutingModule {}
