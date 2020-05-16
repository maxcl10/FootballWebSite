import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// My components
import { GamesComponent } from './games/games-list/games-list.component';

import { GamePosterComponent } from './games/game-poster/game-poster.component';
import { ArticleContainerComponent } from './articles/article-container/article-container.component';

const routes: Routes = [
  {
    path: 'article/:id',
    component: ArticleContainerComponent,
  },

  {
    path: 'games',
    component: GamesComponent,
  },
  {
    path: 'poster',
    component: GamePosterComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PublicRoutingModule {}
