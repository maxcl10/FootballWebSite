import { throwError as observableThrowError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { RankingHistory } from '../../shared/models/rankingHistory.model';
import { Stricker } from '../../shared/models/stricker.model';
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
  private strickers: Observable<Stricker[]>;

  constructor(private http: HttpClient) {}

  public getShape(): Observable<string[]> {
    return this.http.get<string[]>(this.statsUrl + '/shape');
  }

  public getStricker(id: string): Observable<Stricker> {
    return this.http.get<Stricker>(this.statsUrl + '/strickers' + id);
  }

  public getStrickers(): Observable<Stricker[]> {
    return this.http.get<Stricker[]>(this.statsUrl + '/strickers');
  }

  public getScoredGoalsPerGame(): Observable<number> {
    return this.http.get<number>(this.statsUrl + '/scoredPerGame');
  }

  public getConcededGoalsPerGame(): Observable<number> {
    return this.http.get<number>(this.statsUrl + '/concededPerGame');
  }

  public getTeamStrickers(): Observable<Stricker[]> {
    if (this.strickers) {
      return this.strickers;
    }
    this.strickers = this.http.get<Stricker[]>(
      this.statsUrl + '/team/strickers'
    );
    return this.strickers;
  }

  public getRankingHistory(): Observable<RankingHistory[]> {
    return this.http.get<RankingHistory[]>(
      this.statsUrl + '/getRankingHistory'
    );
  }

  public saveStricker(stricker: Stricker): Observable<Stricker> {
    return this.http.post<Stricker>(
      this.statsUrl + '/SetStricker/',
      stricker,
      httpOptions
    );
  }
}
