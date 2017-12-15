import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {tap} from 'rxjs/operators';

import {ShortenDataSource} from '../data-source/shorten-data-source';
import {ShortenDataModel} from '../models/shorten-data.model';

@Injectable()
export class ShortenDataService {
  url = `${this.api}/ShortUrl`;

  constructor(@Inject('api') private api: string,
              private http: HttpClient,
              private shortenDataSource: ShortenDataSource) {}

  save(entity: ShortenDataModel): Observable<ShortenDataModel> {
    return this.http.post<ShortenDataModel>(this.url, entity)
      .pipe(tap(() => this.shortenDataSource.fetchDataFromRemote()));
  }
}
