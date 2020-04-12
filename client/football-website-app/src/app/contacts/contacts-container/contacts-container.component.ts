import { Component, OnInit } from '@angular/core';
import { Club } from '../../shared/models/club.model';
import { Title, DomSanitizer } from '@angular/platform-browser';
import { ClubService } from '../../core/services/club.service';
import { AppConfig } from '../../app.config';

@Component({
  selector: 'fws-contacts-container',
  templateUrl: './contacts-container.component.html',
  styleUrls: ['./contacts-container.component.css'],
})
export class ContactsContainerComponent implements OnInit {
  public errorMessage: string;
  public club: Club;

  public googleMapUrl;
  public url;

  constructor(
    private titleService: Title,
    private service: ClubService,
    public sanitizer: DomSanitizer
  ) {}

  public ngOnInit() {
    this.titleService.setTitle(
      AppConfig.settings.properties.siteName + ' - Contactes'
    );

    this.service.getClub().subscribe((club) => {
      this.club = club;
      if (this.club.googleMap == null) {
        this.club.googleMap = 'Foot ' + this.club.city;
      }
      this.url =
        'https://www.google.com/maps/embed/v1/place?q=' +
        this.club.googleMap +
        '&key=AIzaSyAOPGDDgrY2StsOVlBeslyXXK_yDL4af0A';

      this.googleMapUrl = this.sanitizer.bypassSecurityTrustResourceUrl(
        this.url
      );
    });
  }
}
