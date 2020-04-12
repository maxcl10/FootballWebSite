import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlayerContainerComponent } from './player-container/player-container.component';

const routes: Routes = [{ path: ':id', component: PlayerContainerComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PlayersRoutingModule {}
