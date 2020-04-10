import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { LogoService } from '../../../core/services/logo.service';
import { Game } from '../../../shared/models/game.model';
import { Event } from '../../../shared/models/event.model';
import { GamePlayer } from '../../../shared/models/game-player.model';

@Component({
  selector: 'fws-game-poster-generator',
  templateUrl: './game-poster-generator.component.html',
  styleUrls: ['./game-poster-generator.component.scss']
})
export class GamePosterGeneratorComponent implements OnInit {
  public games: Game[];

  constructor(
    private gamesService: GamesService,
    private logoService: LogoService
  ) {}

  public ngOnInit() {
    const game1 = new Game();
    game1.HomeTeam = 'BURNHAUPT LE HT';
    game1.AwayTeam = 'FCB I';
    game1.HomeTeamScore = 0;
    game1.AwayTeamScore = 1;
    game1.Result = 'W';
    game1.Championship = 'B. Couve';

    const game2 = new Game();
    game2.HomeTeam = 'FCB II';
    game2.AwayTeam = 'RAEDERSDORF';
    game2.HomeTeamScore = 1;
    game2.AwayTeamScore = 1;
    game2.Championship = 'E. Mangin';
    game2.Result = 'D';

    const game3 = new Game();
    game3.HomeTeam = 'HOCHSTATT';
    game3.AwayTeam = 'FCB III';
    game3.HomeTeamScore = 3;
    game3.AwayTeamScore = 1;
    game3.Championship = 'D. Nuzzo';
    game3.Result = 'L';

    this.games = [];
    this.games.push(game1);
    this.games.push(game2);
    this.games.push(game3);
  }
}
