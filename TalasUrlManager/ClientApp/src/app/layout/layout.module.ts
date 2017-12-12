import {NgModule} from '@angular/core';

import {SharedModule} from '../shared/shared.module';

import {FooterComponent} from './footer/footer.component';
import {HeaderComponent} from './header/header.component';
import {ShortenFormComponent} from './shorten-form/shorten-form.component';
import {
  ShortenInputSectionComponent
} from './shorten-input-section/shorten-input-section.component';
import {ShortenListSectionComponent} from './shorten-list-section/shorten-list-section.component';

@NgModule({
  imports: [SharedModule],
  exports: [
    FooterComponent,
    HeaderComponent,
    ShortenFormComponent,
    ShortenInputSectionComponent,
    ShortenListSectionComponent,
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    ShortenFormComponent,
    ShortenInputSectionComponent,
    ShortenListSectionComponent,
  ]
})
export class LayoutModule {}
