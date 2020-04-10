import { Component, OnInit } from '@angular/core';
import { TeamsService } from '../../../core/services/teams.service';
import { Team } from '../../../shared/models/team.model';

@Component({
  selector: 'fws-clubs-list',
  templateUrl: './clubs-list.component.html',
  styleUrls: ['./clubs-list.component.scss']
})
export class ClubsListComponent implements OnInit {
  teams: Team[];
  errorMessage: any;

  constructor(private teamsService: TeamsService) {}

  ngOnInit() {
    this.teamsService.getTeams().subscribe(
      teams => {
        this.teams = teams;
      },
      error => {
        this.errorMessage = error;
      }
    );
  }
}
