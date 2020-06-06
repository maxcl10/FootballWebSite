import { Component, OnInit } from '@angular/core';
import { RankingsService } from '../rankings.service';
import { Ranking } from '../../shared/models/league-table.model';
import { TeamsService } from '../../core/services/teams.service';

@Component({
  selector: 'fws-ranking-table-small',
  templateUrl: './ranking-table-small.component.html',
})
export class LeagueTableSmallComponent implements OnInit {
  public rankings: Ranking[];
  public errorMessage: string;
  public homeTeam: string;

  constructor(
    private rankingService: RankingsService,
    private teamsService: TeamsService
  ) {}

  public ngOnInit() {
    this.teamsService.getOwnerTeams().subscribe(
      (homeTeams) => {
        this.homeTeam = homeTeams[0].name;
        this.getRankings();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getRankings() {
    this.rankingService.getRankings().subscribe(
      (rankings) => {
        const myTeamPosition = rankings.find((o) => o.team === this.homeTeam)
          .position;
        if (myTeamPosition <= 2) {
          // We want to display the 3 first and the two latest
          const firstTeams = rankings.filter((o) => o.position <= 3);
          this.rankings = firstTeams;

          const latestTeams = rankings.filter((o) => o.position > 12);
          latestTeams.forEach((element) => {
            this.rankings.push(element);
          });
        } else if (myTeamPosition >= 11) {
          // We want to display the 2 first and the 3 latest
          const firstTeams = rankings.filter((o) => o.position <= 2);
          this.rankings = firstTeams;

          const latestTeams = rankings.filter((o) => o.position > 10);
          latestTeams.forEach((element) => {
            this.rankings.push(element);
          });
        } else {
          const firstTeams = rankings.filter((o) => o.position <= 2);
          this.rankings = firstTeams;

          let middleTeams;
          if (myTeamPosition === 3) {
            middleTeams = rankings.filter(
              (o) =>
                o.position === myTeamPosition ||
                o.position === myTeamPosition + 1
            );
          } else {
            middleTeams = rankings.filter(
              (o) =>
                o.position >= myTeamPosition - 1 &&
                o.position <= myTeamPosition + 1
            );
          }

          middleTeams.forEach((element) => {
            this.rankings.push(element);
          });

          const latestTeams = rankings.filter((o) => o.position > 12);
          latestTeams.forEach((element) => {
            this.rankings.push(element);
          });
        }
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
