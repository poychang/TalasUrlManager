import {NgModule, Optional, SkipSelf} from '@angular/core';

import {ShortenDataSource} from './data-source/shorten-data-source';
import {throwIfAlreadyLoaded} from './module-import-guard';
import {ShortenDataService} from './services/shorten-data.service';

@NgModule({
  imports: [],
  exports: [],
  declarations: [],
  providers: [ShortenDataSource, ShortenDataService]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
