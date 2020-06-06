import { Component, OnInit } from '@angular/core';
import { TeamsService } from '../../../core/services/teams.service';
import { Team } from '../../../shared/models/team.model';
import { Router } from '@angular/router';

@Component({
  selector: 'fws-teams-container',
  templateUrl: './teams-container.component.html',
  styleUrls: ['./teams-container.component.css'],
})
export class TeamsContainerComponent implements OnInit {
  teams: Team[];

  constructor(private teamService: TeamsService, private router: Router) {}

  ngOnInit(): void {
    this.teamService.getOwnerTeams().subscribe((teams) => {
      this.teams = teams;
    });
  }

  public onselect(team: Team) {
    this.router.navigate(['admin/clubs', team.id, 'edit']);
  }
}
