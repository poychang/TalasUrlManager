import {NgModule} from '@angular/core';

import {LayoutModule} from '../layout/layout.module';

import {DefaultComponent} from './default/default.component';

@NgModule({
  imports: [LayoutModule],
  exports: [DefaultComponent],
  declarations: [DefaultComponent]
})
export class PagesModule {}
