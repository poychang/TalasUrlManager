import {NgModule, Optional, SkipSelf} from '@angular/core';

import {ShortenDataSource} from './data-source/shorten-data-source';
import {throwIfAlreadyLoaded} from './module-import-guard';
import {ConfigurationService} from './services/configuration.service';
import {ShortenDataService} from './services/shorten-data.service';

@NgModule({
  imports: [],
  exports: [],
  declarations: [],
  providers: [ShortenDataSource, ConfigurationService, ShortenDataService]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
