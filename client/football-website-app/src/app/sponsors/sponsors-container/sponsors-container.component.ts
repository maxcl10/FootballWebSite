import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { SponsorsService } from '../../core/services/sponsors.service';
import { Observable } from 'rxjs';
import { Sponsor } from '../../shared/models/sponsor.model';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-sponsors-container',
  templateUrl: './sponsors-container.component.html',
  styleUrls: ['./sponsors-container.component.css'],
})
export class SponsorsContainerComponent implements OnInit {
  constructor(private titleService: Title, private service: SponsorsService) {}

  public sponsors$: Observable<Sponsor[]>;

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Partenaires'
    );

    this.sponsors$ = this.service.getSponsors();
  }
}
