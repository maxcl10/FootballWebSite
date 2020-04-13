import { Component, OnInit, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { SponsorsService } from '../../core/services/sponsors.service';
import { Observable } from 'rxjs';
import { Sponsor } from '../../shared/models/sponsor.model';
import { AppConfig } from '../../app.config';
import { SubSink } from 'subsink';

@Component({
  selector: 'fws-sponsors-container',
  templateUrl: './sponsors-container.component.html',
  styleUrls: ['./sponsors-container.component.css'],
})
export class SponsorsContainerComponent implements OnInit, OnDestroy {
  constructor(private titleService: Title, private service: SponsorsService) {}

  private subs = new SubSink();

  sponsors: Sponsor[];
  loading = false;

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Partenaires'
    );

    this.loading = true;

    this.subs.sink = this.service.getSponsors().subscribe((sponsors) => {
      this.sponsors = sponsors;
      this.loading = false;
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
