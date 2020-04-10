import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { SponsorsService } from '../../../core/services/sponsors.service';
import { Sponsor } from '../../../shared/models/sponsor.model';
import { AppConfig } from '../../../app.config';
import { Observable } from 'rxjs';

@Component({
  selector: 'fws-player',
  templateUrl: './sponsor.component.html'
})
export class SponsorComponent implements OnInit {
  constructor(private titleService: Title, private service: SponsorsService) {}

  public sponsors$: Observable<Sponsor[]>;

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Partenaires'
    );

    this.sponsors$ = this.service.getSponsors();
  }
}
