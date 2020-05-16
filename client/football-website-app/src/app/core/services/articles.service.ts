import { throwError as observableThrowError, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Article } from '../../shared/models/article.model';
import { AppConfig } from '../../app.config';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ArticlesService {
  private articleUrl = AppConfig.settings.apiServer.url + 'articles';

  constructor(private http: HttpClient) {}

  public getArticle(id: string): Observable<Article> {
    return this.http.get<Article>(this.articleUrl + '/' + id);
  }

  public getArticles(): Observable<Article[]> {
    return this.http.get<Article[]>(this.articleUrl);
  }

  public createArticle(article: Article): Observable<Article> {
    return this.http.post<Article>(this.articleUrl, article, httpOptions);
  }

  public updateArticle(article: Article): Observable<Article> {
    return this.http.put<Article>(
      this.articleUrl + '/' + article.id,
      article,
      httpOptions
    );
  }

  public deleteArticle(id: string) {
    return this.http.delete(this.articleUrl + '/' + id);
  }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    const errMsg = error.message || error.statusText || 'Server error';
    console.error(errMsg); // log to console instead
    return observableThrowError(errMsg);
  }
}
