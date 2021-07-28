import { Component, OnInit } from '@angular/core';
import { GamePlayer } from '../../shared/models/game-player.model';
import { Game } from '../../shared/models/game.model';
import { Article } from '../../shared/models/article.model';
import { PlayerEvents } from '../../shared/models/player-event.model';
import { GamesService } from '../../core/services/games.service';
import { ActivatedRoute } from '@angular/router';
import { LogoService } from '../../core/services/logo.service';
import { Event } from '../../shared/models/event.model';
import { Team } from '../../shared/models/team.model';
import { TeamsService } from '../../core/services/teams.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'fws-game-container',
  templateUrl: './game-container.component.html',
  styleUrls: ['./game-container.component.scss'],
})
export class GameContainerComponent implements OnInit {
  game: Game;
  players: GamePlayer[];
  goals: Event[];
  article: Article;
  groupByPlayer: PlayerEvents[];

  constructor(
    private gameService: GamesService,
    private route: ActivatedRoute,
    private logoService: LogoService,
    private teamService: TeamsService
  ) {}

  order = [
    'GB',
    'DD',
    'DG',
    'DCG',
    'DCD',
    'DCC',
    'ALD',
    'ALG',
    'MDC',
    'MDG',
    'MRG',
    'MG',
    'MC',
    'MDD',
    'MRD',
    'MD',
    'MOG',
    'MOD',
    'MOC',
    'AVD',
    'AVC',
    'AVG',
    'R1',
    'R2',
    'R3',
    'R4',
    'R5',
    'R6',
    'R7',
    'R8',
    'R9',
    'R10',
    'R11',
  ];

  ngOnInit() {
    this.route.params.subscribe((params) => {
      const id = params['id'];

      this.gameService.getGame(id).subscribe((game) => {
        this.game = game;

        this.game.homeTeamLogoUrl = this.logoService.getLogoPath(
          game.homeTeam,
          100
        );
        this.game.awayTeamLogoUrl = this.logoService.getLogoPath(
          game.awayTeam,
          100
        );
      });

      this.gameService.getGamePlayers(id).subscribe((players) => {
        this.players = players.sort((a, b) => {
          return (
            this.order.findIndex((o) => o === a.position) -
            this.order.findIndex((o) => o === b.position)
          );
        });
      });

      this.groupByPlayer = new Array();

      this.gameService.getGameEvents(id).subscribe((events) => {
        events
          .filter((o) => o.eventTypeId === 0)
          .sort((a, b) => {
            return a.time - b.time;
          })
          .forEach((event) => {
            const item = this.groupByPlayer.find(
              (o) => o.playerId === event.playerId
            );
            if (item) {
              item.goals.push(event);
            } else {
              const newItem = new PlayerEvents();
              newItem.playerId = event.playerId;
              newItem.firstName = event.playerFirstName;
              newItem.lastName = event.playerLastName;
              newItem.goals = [event];

              this.groupByPlayer.push(newItem);
            }
          });
        // this.groupByPlayer = _.chain(events)
        //   .groupBy('playerId')
        //   .map(function(el) {
        //     let playerEvent = new PlayerEvents();
        //     playerEvent.playerId = el
        //   });

        this.goals = events
          .filter((o) => o.eventTypeId === 0)
          .sort((a, b) => {
            return a.time - b.time;
          });

        this.gameService.getGameArticle(id).subscribe((article) => {
          this.article = article;
        });
      });
    });
  }
}
