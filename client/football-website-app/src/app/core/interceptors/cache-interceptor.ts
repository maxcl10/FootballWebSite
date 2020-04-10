import {
  HttpInterceptor,
  HttpEvent,
  HttpHandler,
  HttpRequest,
  HttpResponse
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpCacheService } from '../services/http-cache.service';
import { tap } from 'rxjs/operators';

// if we need to cache only specific api data
const cachableUrl = 'http://sw-frasws-dev06/User/MMAX/ScpWebApi/customer';

@Injectable()
export class CacheInterceptor implements HttpInterceptor {
  /**
   *
   */
  constructor(private cacheService: HttpCacheService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // pass along non cacheable requests and invaldiate the cache => to improve
    if (req.method !== 'GET') {
      this.cacheService.invalidateCache();
      return next.handle(req);
    }

    // attempt to retrieve a cached response
    const cachedResponse: HttpResponse<any> = this.cacheService.get(req.url);

    // return cached response
    if (cachedResponse) {
      return of(cachedResponse);
    }

    // send request to the server and add response to cache
    return next.handle(req).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          this.cacheService.put(req.url, event);
        }
      })
    );
  }
  /**
   *  If we need to cache only data from a specific url we can use this method
   * @param req
   */
  private isRequestCachable(req: HttpRequest<any>) {
    return req.method === 'GET' && req.url.indexOf(cachableUrl) > -1;
  }
}
