import { Component, OnInit } from '@angular/core';
import { AppConfig } from '../../app.config';
import { Player } from '../../shared/models/player.model';
import { PlayersService } from '../../core/services/players.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../core/services/authentication.service';
import { SeoService } from '../../core/services/seo.service';
import { StatsService } from '../../core/services/stats.service';
import { PlayerStats } from '../../shared/models/stricker.model';

@Component({
  selector: 'fws-player-container',
  templateUrl: './player-container.component.html',
  styleUrls: ['./player-container.component.css'],
})
export class PlayerContainerComponent implements OnInit {
  player: Player;
  errorMessage: string;
  private sub: any;
  isAuthenticated: boolean;
  stats: PlayerStats;

  public get playerAge(): number {
    return this.getAge(this.player.dateOfBirth);
  }

  constructor(
    private playerService: PlayersService,
    private statsService: StatsService,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private seoService: SeoService
  ) {
    this.player = new Player();
  }

  public ngOnInit() {
    this.sub = this.route.params.subscribe((params) => {
      const id = params['id'];
      this.getPlayer(id);
      this.getStats(id);
    });
    this.isAuthenticated = this.authenticationService.isLoggedIn();
  }
  getStats(id: string) {
    this.statsService.getPlayerStats(id).subscribe((res) => {
      this.stats = res;
    });
  }

  public getPlayer(id: string) {
    this.playerService.getplayer(id).subscribe(
      (player) => {
        this.player = player;

        this.seoService.setTitle(
          AppConfig.settings.properties.siteName +
            ' - ' +
            this.player.lastName +
            ' ' +
            this.player.firstName
        );
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getAge(dateString) {
    const today = new Date();
    const birthDate = new Date(dateString);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }

  public goToEdit() {
    this.router.navigate(['admin/players', this.player.id, 'edit']);
  }

  public goBack() {
    window.history.back();
  }
}
