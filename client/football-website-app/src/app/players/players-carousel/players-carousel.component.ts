import { Component, OnInit } from '@angular/core';
import { Player } from '../../shared/models/player.model';
import { TeamsService } from '../../core/services/teams.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'fws-players-carousel',
  templateUrl: './players-carousel.component.html',
  styleUrls: ['./players-carousel.component.css'],
})
export class PlayersCarouselComponent implements OnInit {
  players: Player[];
  player: Player;
  errorMessage: string;

  constructor(
    private playerService: TeamsService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  private sub: any;

  ngOnInit() {
    this.player = new Player();
    this.getPlayers();
  }

  changePlayer(players: Player[]) {
    const index = Math.round(Math.random() * (players.length - 2) + 1);
    this.player = players[index];
  }

  getPlayers() {
    this.playerService.getCurrentPlayers().subscribe(
      (players) => {
        this.players = players;
        this.changePlayer(players);
        setInterval(() => this.changePlayer(players), 15000);
      },

      (error) => (this.errorMessage = <any>error)
    );
  }

  getIndex(player: Player) {
    const index = this.players.indexOf(player);
    alert(index);
    return index;
  }
}
