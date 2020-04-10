import { Component, OnInit } from '@angular/core';
import { Player } from '../../../shared/models/player.model';
import { Stricker } from '../../../shared/models/stricker.model';
import { StatsService } from '../../../core/services/stats.service';
import { TeamsService } from '../../../core/services/teams.service';

@Component({
  selector: 'fws-player-stats-list',
  templateUrl: './player-stats-list.component.html'
})
export class PlayerStatsListComponent implements OnInit {
  public players: Player[];
  public strickers: Stricker[];
  constructor(
    private statService: StatsService,
    private teamService: TeamsService
  ) {}

  ngOnInit() {
    this.statService.getTeamStrickers().subscribe(result => {
      this.strickers = result;
    });
    // this.teamService.getHomeTeams().subscribe(teams => {
    //   const firstTeamId = teams[0].id;

    //   // Get the players from the teams
    //   this.teamService.getPlayers(firstTeamId).subscribe(players => {
    //     this.players = players;
    //   });
    // });
  }
}
