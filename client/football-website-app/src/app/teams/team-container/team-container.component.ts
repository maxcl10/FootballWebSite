import { Component, OnInit } from '@angular/core';
import { Player } from '../../shared/models/player.model';
import { PlayersService } from '../../core/services/players.service';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { TeamsService } from '../../core/services/teams.service';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-team-container',
  templateUrl: './team-container.component.html',
  styleUrls: ['./team-container.component.css'],
})
export class TeamContainerComponent implements OnInit {
  public goalkeeperPlayers: Player[] = [];
  public defenderPlayers: Player[] = [];
  public midfieldPlayers: Player[] = [];
  public attackerPlayers: Player[] = [];
  public coaches: Player[] = [];

  loading: boolean;

  public players: Player[];
  public errorMessage: string;
  private sub: any;

  constructor(
    private playersService: PlayersService,
    private titleService: Title,
    private route: ActivatedRoute,
    private teamService: TeamsService
  ) {}

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Equipe'
    );

    this.sub = this.route.params.subscribe((params) => {
      // Clear because can be redirected from the same page
      this.players = [];
      this.goalkeeperPlayers = [];
      this.defenderPlayers = [];
      this.midfieldPlayers = [];
      this.attackerPlayers = [];
      this.coaches = [];

      this.loading = true;

      const id = params['id'];
      this.teamService.getPlayers(id).subscribe(
        (players) => {
          this.players = players;

          this.players.forEach((element) => {
            if (element.position === 'Milieu') {
              this.midfieldPlayers.push(element);
            } else if (element.position === 'Gardien') {
              this.goalkeeperPlayers.push(element);
            } else if (element.position === 'Defenseur') {
              this.defenderPlayers.push(element);
            } else if (element.position === 'Attaquant') {
              this.attackerPlayers.push(element);
            } else if (
              element.position === 'Entraineur' ||
              element.position === 'Entraineur Adjoint' ||
              element.position === 'Entraineur Gardiens' ||
              element.position === 'Dirigeant'
            ) {
              this.coaches.push(element);
            }
          });
          this.coaches.sort(this.compare);
          this.loading = false;
        },
        (error) => (this.errorMessage = <any>error)
      );
    });
    // this.getPlayers();
  }

  public compare(a: Player, b: Player) {
    if (a.position === 'Entraineur') {
      return 1;
    }

    if (a.position === 'Entraineur Adjoint') {
      return 1;
    }
    if (a.position === 'Entraineur Gardiens') {
      return 1;
    }
    if (a.position === 'Dirigeant') {
      return 1;
    }

    return 0;
  }

  public getPlayers() {
    this.playersService.getplayers().subscribe(
      (players) => {
        this.players = players;
        this.players.forEach((element) => {
          if (element.position === 'Milieu') {
            this.midfieldPlayers.push(element);
          } else if (element.position === 'Gardien') {
            this.goalkeeperPlayers.push(element);
          } else if (element.position === 'Defenseur') {
            this.defenderPlayers.push(element);
          } else if (element.position === 'Attaquant') {
            this.attackerPlayers.push(element);
          }
        });
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
