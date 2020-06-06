import { Component, OnInit, TemplateRef } from '@angular/core';
import { Team } from '../../../shared/models/team.model';
import { TeamsService } from '../../../core/services/teams.service';
import { ActivatedRoute } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'fws-edit-club',
  templateUrl: './edit-club.component.html',
  styleUrls: ['./edit-club.component.scss'],
})
export class EditClubComponent implements OnInit {
  team: Team;
  errorMessage: string;
  title: string;
  own: boolean;
  modalRef: BsModalRef;

  constructor(
    private teamsService: TeamsService,
    private route: ActivatedRoute,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const id = params['id'];
      if (id !== '0') {
        this.getTeam(id);
        this.title = 'Editer';
      } else {
        this.team = new Team();
        this.title = 'Ajouter';
      }
    });
  }
  getTeam(id: any): any {
    this.teamsService.getTeam(id).subscribe(
      (team) => {
        this.team = team;
        this.own =
          this.team.ownerId?.toUpperCase() ===
          environment.ownerId?.toUpperCase();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  createTeam() {
    if (this.own) {
      this.team.ownerId = environment.ownerId;
    }
    this.teamsService.createTeam(this.team).subscribe(
      (team) => {
        this.goBack();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  saveTeam() {
    if (this.own) {
      this.team.ownerId = environment.ownerId;
    }
    this.teamsService.updateTeam(this.team).subscribe(
      (team) => {
        this.goBack();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  deleteTeam() {
    this.teamsService.deleteTeam(this.team).subscribe(
      (team) => {
        this.goBack();
        this.modalRef.hide();
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
