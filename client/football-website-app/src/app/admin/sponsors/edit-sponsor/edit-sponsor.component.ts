import { Component, OnInit, TemplateRef } from '@angular/core';
import { Sponsor } from '../../../shared/models/sponsor.model';
import { SponsorsService } from '../../../core/services/sponsors.service';
import { ActivatedRoute } from '@angular/router';
import { splitNsName } from '@angular/compiler';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'fws-edit-sponsor',
  templateUrl: './edit-sponsor.component.html'
})
export class EditSponsorComponent implements OnInit {
  sponsor: Sponsor;
  errorMessage: string;
  title: string;
  modalRef: BsModalRef;

  constructor(
    private sponsorService: SponsorsService,
    private route: ActivatedRoute,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id !== '0') {
        this.title = 'Editer';
        this.getSponsor(id);
      } else {
        this.title = 'Ajouter';
        this.sponsor = new Sponsor();
      }
    });
  }

  getSponsor(id: string): void {
    this.sponsorService.getSponsor(id).subscribe(
      sponsor => {
        this.sponsor = sponsor;
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public createSponsor() {
    this.sponsorService.createSponsor(this.sponsor).subscribe(
      sponsor => {
        this.goBack();
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public saveSponsor() {
    this.sponsorService.updateSponsor(this.sponsor).subscribe(
      sponsor => {
        this.goBack();
      },
      error => (this.errorMessage = <any>error)
    );
  }

  public deleteSponsor() {
    this.sponsorService.deleteSponsor(this.sponsor).subscribe(
      sponsor => {
        this.modalRef.hide();
        this.goBack();
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
