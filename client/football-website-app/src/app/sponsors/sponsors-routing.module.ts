import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SponsorsContainerComponent } from './sponsors-container/sponsors-container.component';

const routes: Routes = [
  {
    path: '',
    component: SponsorsContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SponsorsRoutingModule {}
