import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GamesService } from '../../../core/services/games.service';
import { Game } from '../../../shared/models/game.model';
import { Team } from '../../../shared/models/team.model';
import { TeamsService } from '../../../core/services/teams.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Competition } from '../../../shared/models/competition.model';

@Component({
  selector: 'fws-edit-game',
  templateUrl: './edit-game.component.html',
  providers: [GamesService, TeamsService],
})
export class EditGameComponent implements OnInit {
  public game: Game;
  public errorMessage: string;
  public teams: Team[];
  public saving: boolean;
  public competitions: Competition[];
  public title: string;
  modalRef: BsModalRef;

  constructor(
    private gamesService: GamesService,
    private teamsService: TeamsService,
    private route: ActivatedRoute,
    private modalService: BsModalService
  ) {}

  public ngOnInit() {
    this.getTeams();
    this.getCompetitions();

    this.route.params.subscribe((params) => {
      const id = params['id'];
      if (id !== '0') {
        this.getGame(id);
        this.title = 'Editer';
      } else {
        this.game = new Game();
        this.game.homeTeamId = '';
        this.game.awayTeamId = '';
        this.title = 'Ajouter';
      }
    });
  }

  public getCompetitions() {
    this.gamesService.getCompetitions().subscribe(
      (competitions) => {
        this.competitions = competitions;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
  public getGame(id: string) {
    this.gamesService.getGame(id).subscribe(
      (game) => {
        this.game = game;
        this.game.matchDate = this.game.matchDate;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public createGame() {
    this.saving = true;
    this.gamesService.createGame(this.game).subscribe(
      (game) => {
        this.goBack();
      },
      (error) => {
        this.errorMessage = 'An error occured.';
        this.saving = false;
      },
      () => {
        this.saving = false;
      }
    );
  }

  public saveGame() {
    this.gamesService.updateGame(this.game).subscribe(
      (article) => {
        this.goBack();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getTeams() {
    this.teamsService.getTeams().subscribe(
      (teams) => {
        this.teams = teams;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public deleteGame() {
    this.gamesService.deleteGame(this.game.id).subscribe(
      (article) => {
        this.modalRef.hide();
        this.goBack();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public cancel() {
    this.modalRef.hide();
  }

  public goBack() {
    window.history.back();
  }
}
