import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TeamContainerComponent } from './team-container/team-container.component';

const routes: Routes = [
  {
    path: ':id',
    component: TeamContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TeamsRoutingModule {}
