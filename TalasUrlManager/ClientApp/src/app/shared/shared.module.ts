import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';

import {MaterialModule} from '../shared/material/material.module';

import {DirectiveModule} from './directive/directive.module';

@NgModule({
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, MaterialModule, DirectiveModule],
  exports: [CommonModule, HttpClientModule, ReactiveFormsModule, MaterialModule, DirectiveModule],
  declarations: []
})
export class SharedModule {}
