import { Component, OnInit } from '@angular/core';
import { SponsorsService } from '../../../core/services/sponsors.service';
import { Observable } from 'rxjs';
import { Sponsor } from '../../../shared/models/sponsor.model';
import { Router } from '@angular/router';

@Component({
  selector: 'fws-list-sponsors',
  templateUrl: './list-sponsors.component.html'
})
export class ListSponsorsComponent implements OnInit {
  sponsors$: Observable<Sponsor[]>;

  constructor(
    private sponsorService: SponsorsService,
    private router: Router
  ) {}

  ngOnInit() {
    this.sponsors$ = this.sponsorService.getSponsors();
  }

  onSponsorSelect(sponsor: Sponsor) {
    this.router.navigate(['admin/sponsors', sponsor.sponsorId, 'edit']);
  }
}
