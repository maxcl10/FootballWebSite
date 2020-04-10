import { Component, OnInit } from '@angular/core';
import { Game } from '../../../shared/models/game.model';
import { GamesService } from '../../../core/services/games.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'fws-list-games',
  templateUrl: './list-games.component.html',
  styleUrls: ['./list-games.component.scss']
})
export class ListGamesComponent implements OnInit {
  public games$: Observable<Game[]>;

  constructor(private gameservice: GamesService, private router: Router) {}

  ngOnInit() {
    this.games$ = this.gameservice.getGames();
  }

  public onGameSelect(game: Game) {
    this.goToEditGame(game);
  }

  public goToEditGame(game: Game) {
    this.router.navigate(['/admin/games', game.Id, 'edit']);
  }
}
