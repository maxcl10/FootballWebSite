import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Ranking } from '../../shared/models/league-table.model';
import { AppConfig } from '../../app.config';
import { Competition } from '../../shared/models/competition.model';

@Injectable()
export class LeagueRankingsService {
  private rankingUrl = AppConfig.settings.apiServer.url + '/ranking';
  private updateLafaRankingUrl =
    AppConfig.settings.apiServer.url + '/UpdateRankingFromLafa';

  private championshipDataUrl =
    AppConfig.settings.apiServer.url + '/championship';

  constructor(private http: HttpClient) {}

  // getranking(id: string): Observable<Ranking> {
  //     return this.http.get(this.rankingUrl + "/" + id)
  //         .map(response => response.json())
  //         .catch(this.handleError);
  // }

  public getRankings(): Observable<Ranking[]> {
    return this.http.get<Ranking[]>(this.rankingUrl);
  }

  public getChampionshipData(): Observable<Competition> {
    return this.http.get<Competition>(this.championshipDataUrl);
  }
  public updateRankingFromLafa() {
    return this.http.get(this.updateLafaRankingUrl);
  }

  // createranking(ranking: Ranking): Observable<Ranking> {
  //     let headers = new Headers({ 'Content-Type': 'application/json' });
  //     return this.http.post(this.rankingUrl, JSON.stringify(ranking), { headers: headers })
  //         .map(response => response.json())
  //         .catch(this.handleError);
  // }

  // updateranking(ranking: Ranking): Observable<Ranking> {
  //     let headers = new Headers({ 'Content-Type': 'application/json' });
  //     return this.http.put(this.rankingUrl + "/" + ranking.id, JSON.stringify(ranking), { headers: headers })
  //         .map(response => response.json())
  //         .catch(this.handleError);
  // }

  // deleteranking(id: string) {
  //     let headers = new Headers({ 'Content-Type': 'application/json' });
  //     return this.http.delete(this.rankingUrl + "/" + id, { headers: headers })
  //         .map(response => response.json())
  //         .catch(this.handleError);
  // }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = error.message || error.statusText || 'Server error';
    console.error(errMsg); // log to console instead
    return observableThrowError(errMsg);
  }
}
