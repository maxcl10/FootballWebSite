import { Injectable } from '@angular/core';
import { Event } from '../../shared/models/event.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppConfig } from '../../app.config';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class EventsService {
  private eventUrl = AppConfig.settings.apiServer.url + 'events';

  /**
   *
   */
  constructor(private http: HttpClient) {}
  addEvent(event: Event) {
    return this.http.post<Event>(this.eventUrl, event, httpOptions);
  }

  deleteEvent(event: Event) {
    return this.http.delete(this.eventUrl + '/' + event.eventId);
  }
}
