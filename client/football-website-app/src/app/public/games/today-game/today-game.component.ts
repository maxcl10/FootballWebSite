import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { LogoService } from '../../../core/services/logo.service';
import { Game } from '../../../shared/models/game.model';

@Component({
  selector: 'fws-today-game',
  templateUrl: './today-game.component.html',
  providers: [GamesService, LogoService]
})
export class TodayGameComponent implements OnInit {
  public game: Game;
  public errorMessage: string;
  public isToday = false;
  public gameType: string;

  constructor(
    private gamesService: GamesService,
    private logoService: LogoService
  ) {}

  public ngOnInit() {
    this.getNextGame();
  }

  public isGameToday(): boolean {
    const today = new Date();
    if (this.game == null) {
      return false;
    }

    const matchDate = new Date(this.game.MatchDate.toString());
    if (
      matchDate.getDate() === today.getDate() &&
      matchDate.getMonth() === today.getMonth() &&
      matchDate.getFullYear() === today.getFullYear()
    ) {
      return true;
    }
    return false;
  }

  public getNextGame() {
    this.gamesService.getNextGame().subscribe(
      game => {
        this.game = game;
        if (game != null) {
          this.game.awayTeamLogoUrl = this.logoService.getLogoPath(
            this.game.AwayTeam,
            100
          );
          this.game.homeTeamLogoUrl = this.logoService.getLogoPath(
            this.game.HomeTeam,
            100
          );
        }

        this.isToday = this.isGameToday();
        this.gameType = this.GetGameType(game);
      },
      error => (this.errorMessage = <any>error)
    );
  }

  private GetGameType(game: Game): string {
    // championnat contain JXX. Therefore I have to use the conatain
    if (game.Championship.includes('Championnat')) {
      return 'Championnat';
    } else {
      return game.Championship;
    }
  }
}
