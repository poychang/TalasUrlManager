import {HttpClient} from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';

import {ConfigurationModel} from '../models/configuratoin.model';

@Injectable()
export class ConfigurationService {
  private _config: ConfigurationModel;
  get config() { return this._config; }

  constructor(private http: HttpClient, @Inject('api') private api: string) {}

  load(): Promise<ConfigurationModel> {
    return this.http.get<ConfigurationModel>(`${this.api}/Configuration`).toPromise().then(data => {
      this._config = data;
      return data;
    });
  }
}
