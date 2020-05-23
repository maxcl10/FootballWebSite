import { throwError as observableThrowError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { RankingHistory } from '../../shared/models/rankingHistory.model';
import { PlayerStats } from '../../shared/models/stricker.model';
import { AppConfig } from '../../app.config';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  private statsUrl = AppConfig.settings.apiServer.url + 'stats';

  constructor(private http: HttpClient) {}

  public getShape(): Observable<string[]> {
    return this.http.get<string[]>(this.statsUrl + '/shape');
  }

  public getPlayerStats(id: string): Observable<PlayerStats> {
    return this.http.get<PlayerStats>(this.statsUrl + '/players/' + id);
  }

  public getPlayersStats(): Observable<PlayerStats[]> {
    return this.http.get<PlayerStats[]>(this.statsUrl + '/players');
  }

  public getScoredGoalsPerGame(): Observable<number> {
    return this.http.get<number>(this.statsUrl + '/scoredPerGame');
  }

  public getConcededGoalsPerGame(): Observable<number> {
    return this.http.get<number>(this.statsUrl + '/concededPerGame');
  }

  public getTeamStrickers(): Observable<PlayerStats[]> {
    return this.http.get<PlayerStats[]>(this.statsUrl + '/team/players');
  }

  public getRankingHistory(): Observable<RankingHistory[]> {
    return this.http.get<RankingHistory[]>(
      this.statsUrl + '/getRankingHistory'
    );
  }

  public saveStricker(stricker: PlayerStats): Observable<PlayerStats> {
    return this.http.post<PlayerStats>(
      this.statsUrl + '/SetStricker/',
      stricker,
      httpOptions
    );
  }
}
