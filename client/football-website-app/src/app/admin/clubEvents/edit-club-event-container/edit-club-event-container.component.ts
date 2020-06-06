import { Component, OnInit, TemplateRef } from '@angular/core';
import { ClubEvent } from '../../../shared/models/club-event.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Game } from '../../../shared/models/game.model';
import { ActivatedRoute } from '@angular/router';
import { GamesService } from '../../../core/services/games.service';
import { ClubEventsService } from '../../../core/services/clubEvents.service';

@Component({
  selector: 'fws-edit-club-event-container',
  templateUrl: './edit-club-event-container.component.html',
  styleUrls: ['./edit-club-event-container.component.css'],
})
export class EditClubEventContainerComponent implements OnInit {
  public clubEvent: ClubEvent;
  public errorMessage: string;
  public title: string;
  modalRef: BsModalRef;
  public games: Game[];

  public tinyMceSettings = {
    inline: false,
    statusbar: false,
    browser_spellcheck: false,
    height: 400,
    plugins: `fullscreen advlist autolink lists link image charmap print preview anchor textcolor
      searchreplace visualblocks code fullscreen insertdatetime media table contextmenu paste code help wordcount`,
    toolbar: `formatselect | bold italic strikethrough forecolor backcolor permanentpen formatpainter
      | link image media pageembed | alignleft aligncenter alignright alignjustify  |
      numlist bullist outdent indent | removeformat | addcomment`,
  };

  constructor(
    private clubEventService: ClubEventsService,
    private route: ActivatedRoute,
    private modalService: BsModalService,
    private gameService: GamesService
  ) {}

  public ngOnInit() {
    this.route.params.subscribe((params) => {
      const id = params['id'];
      if (id !== '0') {
        this.title = 'Editer';
        this.getClubEvent(id);
      } else {
        this.title = 'Ajouter';
        this.clubEvent = new ClubEvent();
      }
    });

    this.gameService.getGames().subscribe((games) => {
      this.games = games;
    });
  }

  public getClubEvent(id: string) {
    this.clubEventService.getClubEvent(id).subscribe(
      (clubEvent) => {
        this.clubEvent = clubEvent;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public createArticle() {
    this.clubEventService.createClubEvents(this.clubEvent).subscribe(
      (res) => {
        this.goBack();
      },
      (error) => (this.errorMessage = error.message)
    );
  }

  public saveArticle() {
    this.clubEventService.updateClubEvent(this.clubEvent).subscribe(
      (res) => {
        this.goBack();
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public deleteArticle() {
    this.clubEventService.deleteClubEvent(this.clubEvent.id).subscribe(
      (result) => {
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
