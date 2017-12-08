import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';

import {MyMaterialModule} from '../shared/my-material.module';

import {FooterComponent} from './footer/footer.component';
import {HeaderComponent} from './header/header.component';
import {
  ShortenInputSectionComponent
} from './shorten-input-section/shorten-input-section.component';
import {ShortenListSectionComponent} from './shorten-list-section/shorten-list-section.component';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, MyMaterialModule],
  exports:
    [HeaderComponent, ShortenInputSectionComponent, ShortenListSectionComponent, FooterComponent],
  declarations:
    [HeaderComponent, ShortenInputSectionComponent, ShortenListSectionComponent, FooterComponent]
})
export class LayoutModule {}
