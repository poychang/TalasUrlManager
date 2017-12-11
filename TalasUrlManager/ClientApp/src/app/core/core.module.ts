import {NgModule, Optional, SkipSelf} from '@angular/core';
import {throwIfAlreadyLoaded} from './module-import-guard';
import {ShortenDataSource} from './data-source/shorten-data-source';

@NgModule({ imports: [], exports: [], declarations: [], providers: [ShortenDataSource] })
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
