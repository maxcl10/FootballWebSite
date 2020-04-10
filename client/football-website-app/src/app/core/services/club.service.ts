import { throwError as observableThrowError, Observable } from 'rxjs';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders
} from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Club } from '../../shared/models/club.model';
import { AppConfig } from '../../app.config';
import { OrganizationalItem } from '../../shared/models/organizational-item.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class ClubService {
  private ownerUrl = AppConfig.settings.apiServer.url + '/owner';

  constructor(private http: HttpClient) {}

  public getClub(): Observable<Club> {
    return this.http.get<Club>(this.ownerUrl);
  }

  public getOrganizationalChart(): Observable<OrganizationalItem[]> {
    return this.http.get<OrganizationalItem[]>(
      '../../../assets/fcb_organigramme.json'
    );
  }

  // private handleError(error: HttpErrorResponse) {
  //     if (error.error instanceof ErrorEvent) {
  //         // A client-side or network error occurred. Handle it accordingly.
  //         console.error('An error occurred:', error.error.message);
  //     } else {
  //         // The backend returned an unsuccessful response code.
  //         // The response body may contain clues as to what went wrong,
  //         console.error(
  //             `Backend returned code ${error.status}, ` +
  //             `body was: ${error.error}`);
  //     }
  //     // return an observable with a user-facing error message
  //     return throwError(
  //         'Something bad happened; please try again later.');
  // };
}
