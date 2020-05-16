import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { LogoService } from '../../../core/services/logo.service';
import { Game } from '../../../shared/models/game.model';
import { Event } from '../../../shared/models/event.model';
import { GamePlayer } from '../../../shared/models/game-player.model';

@Component({
  selector: 'fws-game-poster-generator',
  templateUrl: './game-poster-generator.component.html',
  styleUrls: ['./game-poster-generator.component.scss'],
})
export class GamePosterGeneratorComponent implements OnInit {
  public games: Game[];

  constructor(
    private gamesService: GamesService,
    private logoService: LogoService
  ) {}

  public ngOnInit() {
    const game1 = new Game();
    game1.homeTeam = 'BURNHAUPT LE HT';
    game1.awayTeam = 'FCB I';
    game1.homeTeamScore = 0;
    game1.awayTeamScore = 1;
    game1.result = 'W';
    game1.championship = 'B. Couve';

    const game2 = new Game();
    game2.homeTeam = 'FCB II';
    game2.awayTeam = 'RAEDERSDORF';
    game2.homeTeamScore = 1;
    game2.awayTeamScore = 1;
    game2.championship = 'E. Mangin';
    game2.result = 'D';

    const game3 = new Game();
    game3.homeTeam = 'HOCHSTATT';
    game3.awayTeam = 'FCB III';
    game3.homeTeamScore = 3;
    game3.awayTeamScore = 1;
    game3.championship = 'D. Nuzzo';
    game3.result = 'L';

    this.games = [];
    this.games.push(game1);
    this.games.push(game2);
    this.games.push(game3);
  }
}
