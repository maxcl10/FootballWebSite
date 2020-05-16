import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Ranking } from '../shared/models/league-table.model';
import { AppConfig } from '../app.config';
import { Competition } from '../shared/models/competition.model';

@Injectable({
  providedIn: 'root',
})
export class RankingsService {
  private rankingUrl = AppConfig.settings.apiServer.url + '/rankings';
  private updateLafaRankingUrl =
    AppConfig.settings.apiServer.url + '/UpdateRankingFromLafa';

  private championshipDataUrl =
    AppConfig.settings.apiServer.url + '/championship';

  constructor(private http: HttpClient) {}

  public getRankings(): Observable<Ranking[]> {
    return this.http.get<Ranking[]>(this.rankingUrl);
  }

  public getChampionshipData(): Observable<Competition> {
    return this.http.get<Competition>(this.championshipDataUrl);
  }
  public updateRankingFromLafa() {
    return this.http.get(this.updateLafaRankingUrl);
  }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = error.message || error.statusText || 'Server error';
    console.error(errMsg); // log to console instead
    return observableThrowError(errMsg);
  }
}
