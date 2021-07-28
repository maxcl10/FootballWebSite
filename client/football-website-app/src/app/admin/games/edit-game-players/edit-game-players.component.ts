import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { Player } from '../../../shared/models/player.model';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../../../shared/models/game.model';
import { TeamsService } from '../../../core/services/teams.service';
import { GamePlayer } from '../../../shared/models/game-player.model';
import { Event } from '../../../shared/models/event.model';
import { EventsService } from '../../../core/services/events.service';
import { PlayersService } from '../../../core/services/players.service';
import { EventType } from '../../../shared/models/eventType.model';

@Component({
  selector: 'fws-edit-game-players',
  templateUrl: './edit-game-players.component.html',
  styleUrls: ['./edit-game-players.component.scss'],
})
export class EditGamePlayersComponent implements OnInit {
  gamePlayers: GamePlayer[];
  newGamePlayer: GamePlayer;
  events: Event[];
  newEvent: Event;
  selectedGamePlayer: GamePlayer;
  selectedGamePlayerEvents: Event[];
  players: Player[];
  selectedPlayer: Player;
  game: Game;
  position: string;
  eventTypes: EventType[];

  constructor(
    private gamesService: GamesService,
    private teamsService: TeamsService,
    private playersService: PlayersService,
    private route: ActivatedRoute,
    private eventsService: EventsService
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
    'MD',
    'MOD',
    'MC',
    'MDD',
    'MRD',
    'MG',
    'MOG',
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
      this.newGamePlayer = new GamePlayer();

      const id = params['id'];
      this.gamesService.getGamePlayers(id).subscribe((players) => {
        this.gamePlayers = players.sort((a, b) => {
          return (
            this.order.findIndex((o) => o === a.position) -
            this.order.findIndex((o) => o === b.position)
          );
        });

        this.gamesService.getGameEvents(id).subscribe((events) => {
          this.events = events;

          this.gamePlayers.forEach((element) => {
            element.events = this.events.filter(
              (o) => o.gamePlayerId === element.id
            );
          });
        });
      });

      this.gamesService.getGame(id).subscribe((game) => {
        this.game = game;
      });

      this.playersService.getCurrentPlayers().subscribe((players) => {
        this.players = players;
      });

      this.gamesService.getEventTypes().subscribe((eventTypes) => {
        this.eventTypes = eventTypes;
      });
    });
  }

  addPlayer() {
    this.gamesService
      .addGamePlayer(this.game.id, this.newGamePlayer)
      .subscribe((result) => {
        this.gamePlayers.push(result);
        this.newGamePlayer = new GamePlayer();
      });
  }

  selectGamePlayer(gamePlayer: GamePlayer) {
    this.selectedGamePlayer = gamePlayer;
    this.newEvent = new Event();
    this.newEvent.gamePlayerId = gamePlayer.id;
    this.newEvent.playerFirstName = gamePlayer.playerFirstName;
    this.newEvent.playerLastName = gamePlayer.playerLastName;
    this.selectedGamePlayerEvents = this.events.filter(
      (o) => o.gamePlayerId === gamePlayer.id
    );
  }

  removePlayer(player: GamePlayer) {
    this.gamesService
      .deleteGamePlayer(this.game.id, player.playerId)
      .subscribe(() => {
        const index = this.gamePlayers.indexOf(player);
        this.gamePlayers.splice(index, 1);
      });
  }

  addEvent() {
    this.newEvent.gamePlayerId = this.selectedGamePlayer.id;
    this.eventsService.addEvent(this.newEvent).subscribe((result) => {
      this.events.push(result);
      this.selectedGamePlayerEvents.push(result);

      this.gamePlayers
        .find((o) => o.playerId === this.selectedGamePlayer.playerId)
        .events.push(result);
    });
  }

  delete(event: Event) {
    this.eventsService.deleteEvent(event).subscribe(() => {
      // Remove from the event list
      let index = this.events.indexOf(event);
      this.events.splice(index, 1);

      // Remove from the selected list
      index = this.selectedGamePlayerEvents.indexOf(event);
      this.selectedGamePlayerEvents.splice(index, 1);

      // Remove from the table
      const selectedGamePlayer = this.gamePlayers.find(
        (o) => o.playerId === this.selectedGamePlayer.playerId
      );

      index = selectedGamePlayer.events.indexOf(event);
      selectedGamePlayer.events.splice(index, 1);
    });
  }
}
