import {NgModule} from '@angular/core';

import {MyMaterialModule} from '../shared/my-material.module';

import {HeaderComponent} from './header/header.component';

@NgModule({
  imports: [MyMaterialModule],
  exports: [HeaderComponent],
  declarations: [HeaderComponent]
})
export class LayoutModule {}
