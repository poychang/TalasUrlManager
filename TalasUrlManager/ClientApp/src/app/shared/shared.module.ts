import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';

import {MyMaterialModule} from '../shared/my-material.module';

import {ShowErrorMessageDirective} from './show-error-message.directive';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, MyMaterialModule],
  exports: [CommonModule, ReactiveFormsModule, MyMaterialModule, ShowErrorMessageDirective],
  declarations: [ShowErrorMessageDirective]
})
export class SharedModule {}
