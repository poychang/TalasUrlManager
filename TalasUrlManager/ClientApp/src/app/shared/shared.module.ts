import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {MaterialModule} from '../shared/material/material.module';

import {DirectiveModule} from './directive/directive.module';
import {LimitStrLenPipe} from './pipe/limit-str-len.pipe';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DirectiveModule
  ],
  exports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DirectiveModule,
    LimitStrLenPipe
  ],
  declarations: [LimitStrLenPipe]
})
export class SharedModule {}
