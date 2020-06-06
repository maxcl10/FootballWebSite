import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfig } from '../../app.config';
import { Player } from '../../shared/models/player.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class PlayersService {
  private playerUrl = AppConfig.settings.apiServer.url + 'players';

  constructor(private http: HttpClient) {}

  public getplayer(id: string): Observable<Player> {
    return this.http.get<Player>(this.playerUrl + '/' + id);
  }

  public getAllPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.playerUrl);
  }

  public createplayer(player: Player): Observable<Player> {
    return this.http.post<Player>(this.playerUrl, player, httpOptions);
  }

  public getCurrentPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.playerUrl + '/current');
  }

  public updateplayer(player: Player): Observable<Player> {
    return this.http.put<Player>(
      this.playerUrl + '/' + player.id,
      player,
      httpOptions
    );
  }

  public deleteplayer(id: string) {
    return this.http.delete(this.playerUrl + '/' + id);
  }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = error.message || error.statusText || 'Server error';
    console.error(errMsg); // log to console instead
    return observableThrowError(errMsg);
  }
}
