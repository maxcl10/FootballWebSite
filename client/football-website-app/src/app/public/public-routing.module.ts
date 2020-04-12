import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// My components
import { HomeComponent } from './home/home/home.component';
import { HistoryComponent } from './club/history/history.component';
import { GamesComponent } from './games/games-list/games-list.component';
import { LoginComponent } from './login/login.component';
import { OrganizationalChartComponent } from './club/organizational-chart/organizational-chart.component';

import { GamePosterComponent } from './games/game-poster/game-poster.component';
import { ArticleContainerComponent } from './articles/article-container/article-container.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },

  {
    path: 'club/history',
    component: HistoryComponent,
  },
  {
    path: 'club/organizational-chart',
    component: OrganizationalChartComponent,
  },

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
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '**',
    component: HomeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PublicRoutingModule {}
