import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../../shared/models/user.model';
import { AppConfig } from '../../app.config';

@Injectable()
export class AuthenticationService {
  private playerUrl = AppConfig.settings.apiServer.url + '/authentication';
  redirectUrl: string;

  constructor(private http: HttpClient) {}

  public authenticate(user: string, password: string): Observable<User> {
    return this.http.get<User>(this.playerUrl + '/' + user + '/' + password);
  }
  public logout() {
    sessionStorage.removeItem('user');
  }

  public getLoggedUser(): User {
    return JSON.parse(sessionStorage.getItem('user'));
  }

  public isLoggedIn() {
    if (sessionStorage.getItem('user') === null) {
      return false;
    }

    return true;
  }
}
