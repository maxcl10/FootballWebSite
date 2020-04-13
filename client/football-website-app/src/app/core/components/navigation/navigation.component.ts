import { Component, OnInit } from '@angular/core';
import { TeamsService } from '../../services/teams.service';
import { Team } from '../../../shared/models/team.model';

@Component({
  selector: 'fws-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
})
export class NavigationComponent implements OnInit {
  errorMessage: string;
  constructor(private teamsService: TeamsService) {}

  public teams: Team[];

  ngOnInit(): void {
    this.teamsService.getHomeTeams().subscribe(
      (homeTeams) => {
        this.teams = homeTeams;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
