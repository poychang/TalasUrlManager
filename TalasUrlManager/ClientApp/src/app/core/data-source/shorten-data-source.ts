import {HttpClient} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';
import {Observable} from 'rxjs/Observable';
import {from} from 'rxjs/observable/from';

import {ShortenDataModel} from '../models/shorten-data.model';

@Injectable()
export class ShortenDataSource extends MatTableDataSource<ShortenDataModel> {
  get data$(): Observable<ShortenDataModel> { return from(this.data); }

  constructor(@Inject('api') private api: string, private http: HttpClient) {
    super();
    this._fetchDataFromRemote();
  }

  private _fetchDataFromRemote() {
    this.http.get<ShortenDataModel[]>(`${this.api}/ShortUrl`).subscribe(dataset => {
      this.data = [...this.data, ...dataset];
    });
  }

  fetchMoreData() {
    // TODO: Implement lazy load. Load more date from remote. Need OData support.
    console.log('Fetch more data functionality is not implement Yet!');
  }
}
