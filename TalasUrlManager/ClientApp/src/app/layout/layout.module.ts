import {NgModule} from '@angular/core';

import {MyMaterialModule} from '../shared/my-material.module';

import {HeaderComponent} from './header/header.component';
import {ShortenInputSectionComponent} from './shorten-input-section/shorten-input-section.component';

@NgModule({
  imports: [MyMaterialModule],
  exports: [HeaderComponent, ShortenInputSectionComponent],
  declarations: [HeaderComponent, ShortenInputSectionComponent]
})
export class LayoutModule {}
