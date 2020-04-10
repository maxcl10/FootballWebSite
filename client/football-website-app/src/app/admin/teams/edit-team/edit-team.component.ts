import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

import { Player } from '../../../shared/models/player.model';
import { TeamsService } from '../../../core/services/teams.service';
import { Team } from '../../../shared/models/team.model';
import { PlayersService } from '../../../core/services/players.service';

// import { DragulaService } from 'ng2-dragula/ng2-dragula';

@Component({
  selector: 'fws-edit-team',
  templateUrl: './edit-team.component.html',
  providers: [TeamsService]
})
export class EditTeamComponent implements OnInit {
  public allPlayersPool: Player[];
  public poolPlayers: Player[];
  public teamPlayers: Player[];
  public localTeams: Team[];
  public errorMessage: string;
  public selectedTeam: string;
  public query: string;

  constructor(
    private teamService: TeamsService,
    private playersService: PlayersService
  ) {
    this.playersService.getplayers().subscribe(players => {
      if (this.selectedTeam === undefined) {
        this.selectedTeam = 'b8bc86da-9eea-4820-a5d5-c9f57b3b7d80';
      }
      this.allPlayersPool = players;
      this.updateList(players);
    });
  }

  private updateList(players: Player[]) {
    this.teamService.getPlayers(this.selectedTeam).subscribe(
      teamPlayers => {
        this.teamPlayers = teamPlayers;
        this.poolPlayers = this.arr_diff(players, teamPlayers);
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public ngOnInit() {
    this.teamService.getHomeTeams().subscribe(teams => {
      this.localTeams = teams;
      this.selectedTeam = teams[0].id;
    });
  }

  private arr_diff(a1: Player[], a2: Player[]): Player[] {
    const buffer = [];
    if (a1 != null && a1 !== undefined) {
      a1.forEach(element => {
        if (a2.filter(o => o.id === element.id).length === 0) {
          buffer.push(element);
        }
      });
    }
    return buffer;
  }

  public add(player: Player) {
    this.teamService.addPlayerInTeam(player.id, this.selectedTeam).subscribe(
      res => {
        if (res === true) {
          this.teamPlayers.push(player);
          const index = this.poolPlayers.indexOf(player);
          this.poolPlayers.splice(index, 1);
        }
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public remove(player: Player) {
    this.teamService
      .removePlayerFromTeam(player.id, this.selectedTeam)
      .subscribe(res => {
        if (res === true) {
          this.poolPlayers.push(player);
          const index = this.teamPlayers.indexOf(player);
          this.teamPlayers.splice(index, 1);
        }
      });
  }

  onTeamChange(deviceValue): void {
    this.updateList(this.allPlayersPool);
  }
}
