import {NgModule} from '@angular/core';
import {DynamicModule} from 'ng-dynamic-component';

import {SharedModule} from '../shared/shared.module';

import {DialogComponentSet} from './dialog/dialog-component-set';
import {QrcodeDialogComponent} from './dialog/qrcode-dialog/qrcode-dialog.component';
import {FooterComponent} from './footer/footer.component';
import {HeaderComponent} from './header/header.component';
import {ShortenFormComponent} from './shorten-form/shorten-form.component';
import {
  ShortenInputSectionComponent
} from './shorten-input-section/shorten-input-section.component';
import {ShortenListSectionComponent} from './shorten-list-section/shorten-list-section.component';

@NgModule({
  imports: [SharedModule, DynamicModule.withComponents([...DialogComponentSet])],
  exports: [
    FooterComponent,
    HeaderComponent,
    ShortenFormComponent,
    ShortenInputSectionComponent,
    ShortenListSectionComponent,
  ],
  declarations: [
    QrcodeDialogComponent,
    FooterComponent,
    HeaderComponent,
    ShortenFormComponent,
    ShortenInputSectionComponent,
    ShortenListSectionComponent,
  ]
})
export class LayoutModule {}
