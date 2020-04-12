import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FixturesContainerComponent } from './fixtures-container/fixtures-container.component';

const routes: Routes = [
  {
    path: '',
    component: FixturesContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FixturesRoutingModule {}
