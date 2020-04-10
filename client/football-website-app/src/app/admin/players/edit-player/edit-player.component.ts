import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PlayersService } from '../../../core/services/players.service';
import { Player } from '../../../shared/models/player.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'fws-edit-player',
  templateUrl: './edit-player.component.html',
  providers: [PlayersService]
})
export class EditPlayerComponent implements OnInit {
  public player: Player;
  public errorMessage: string;
  title: string;
  modalRef: BsModalRef;

  constructor(
    private playersService: PlayersService,
    private route: ActivatedRoute,
    private modalService: BsModalService
  ) {}

  public ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id !== '0') {
        this.title = 'Editer';
        this.getPlayer(id);
      } else {
        this.title = 'Ajouter';
        this.player = new Player();
      }
    });
  }

  public getPlayer(id: string) {
    this.playersService.getplayer(id).subscribe(
      player => {
        this.player = player;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public savePlayer() {
    this.playersService.updateplayer(this.player).subscribe(
      player => {
        this.goBack();
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public createPlayer() {
    this.playersService.createplayer(this.player).subscribe(
      player => {
        this.goBack();
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public deletePlayer() {
    this.playersService.deleteplayer(this.player.id).subscribe(
      result => {
        this.goBack();
        this.modalRef.hide();
      },
      error => (this.errorMessage = <any>error)
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
