import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './user/auth.guard';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'team',
    loadChildren: () =>
      import('./teams/teams.module').then((m) => m.TeamsModule),
  },
  {
    path: 'player',
    loadChildren: () =>
      import('./players/players.module').then((m) => m.PlayersModule),
  },
  {
    path: 'ranking',
    loadChildren: () =>
      import('./ranking/ranking.module').then((m) => m.RankingModule),
  },
  {
    path: 'fixtures',
    loadChildren: () =>
      import('./fixtures/fixtures.module').then((m) => m.FixturesModule),
  },
  {
    path: 'stats',
    loadChildren: () =>
      import('./stats/stats.module').then((m) => m.StatsModule),
  },
  {
    path: 'sponsors',
    loadChildren: () =>
      import('./sponsors/sponsors.module').then((m) => m.SponsorsModule),
  },
  {
    path: 'contacts',
    loadChildren: () =>
      import('./contacts/contacts.module').then((m) => m.ContactsModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
