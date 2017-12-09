import {NgModule} from '@angular/core';

import {SharedModule} from '../shared/shared.module';

import {FooterComponent} from './footer/footer.component';
import {HeaderComponent} from './header/header.component';
import {
  ShortenInputSectionComponent
} from './shorten-input-section/shorten-input-section.component';
import {ShortenListSectionComponent} from './shorten-list-section/shorten-list-section.component';

@NgModule({
  imports: [SharedModule],
  exports:
    [HeaderComponent, ShortenInputSectionComponent, ShortenListSectionComponent, FooterComponent],
  declarations:
    [HeaderComponent, ShortenInputSectionComponent, ShortenListSectionComponent, FooterComponent]
})
export class LayoutModule {}
