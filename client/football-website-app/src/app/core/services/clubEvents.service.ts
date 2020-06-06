import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { AppConfig } from '../../app.config';
import { ClubEvent } from '../../shared/models/club-event.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ClubEventsService {
  private clubEventUrl = AppConfig.settings.apiServer.url + 'clubEvents';

  constructor(private http: HttpClient) {}

  public getClubEvent(id: string): Observable<ClubEvent> {
    return this.http.get<ClubEvent>(this.clubEventUrl + '/' + id);
  }

  public getClubEvents(count?: number): Observable<ClubEvent[]> {
    return this.http.get<ClubEvent[]>(this.clubEventUrl);
  }

  public createClubEvents(clubEvent: ClubEvent): Observable<ClubEvent> {
    return this.http.post<ClubEvent>(this.clubEventUrl, clubEvent, httpOptions);
  }

  public updateClubEvent(clubEvent: ClubEvent): Observable<ClubEvent> {
    return this.http.put<ClubEvent>(
      this.clubEventUrl + '/' + clubEvent.id,
      clubEvent,
      httpOptions
    );
  }

  public deleteClubEvent(id: string) {
    return this.http.delete(this.clubEventUrl + '/' + id);
  }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = error.message || error.statusText || 'Server error';
    console.error(errMsg); // log to console instead
    return observableThrowError(errMsg);
  }
}
