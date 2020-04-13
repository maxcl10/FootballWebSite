import { Component, OnInit } from '@angular/core';
import { PlayersService } from '../../core/services/players.service';
import { GamesService } from '../../core/services/games.service';
import { AuthenticationService } from '../../core/services/authentication.service';
import { ArticlesService } from '../../core/services/articles.service';
import { User } from '../../shared/models/user.model';

@Component({
  selector: 'fws-admin',
  templateUrl: './admin.component.html',
  providers: [
    ArticlesService,
    AuthenticationService,
    PlayersService,
    GamesService,
  ],
})
export class AdminComponent implements OnInit {
  public errorMessage: string;

  user: User;
  constructor(private authenticationService: AuthenticationService) {
    this.user = this.authenticationService.getLoggedUser();
  }

  public ngOnInit() {}

  public _toggleSidebar() {
    // $('#wrapper').toggleClass('toggled');
  }
}
