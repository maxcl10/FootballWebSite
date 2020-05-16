import { throwError as observableThrowError, Observable } from 'rxjs';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sponsor } from '../../shared/models/sponsor.model';
import { AppConfig } from '../../app.config';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class SponsorsService {
  private sponsorsUrl = AppConfig.settings.apiServer.url + 'sponsors';

  constructor(private http: HttpClient) {}

  public getSponsors(): Observable<Sponsor[]> {
    return this.http.get<Sponsor[]>(this.sponsorsUrl);
  }

  public getSponsor(id: string): Observable<Sponsor> {
    return this.http.get<Sponsor>(this.sponsorsUrl + '/' + id);
  }

  public createSponsor(sponsor: Sponsor): Observable<Sponsor> {
    return this.http.post<Sponsor>(this.sponsorsUrl, sponsor, httpOptions);
  }

  public updateSponsor(sponsor: Sponsor): Observable<Sponsor> {
    const url = this.sponsorsUrl + '/' + sponsor.sponsorId;
    return this.http.put<Sponsor>(url, sponsor, httpOptions);
  }

  public deleteSponsor(sponsor: Sponsor): Observable<Sponsor> {
    return this.http.delete<Sponsor>(
      this.sponsorsUrl + '/' + sponsor.sponsorId
    );
  }
}
