import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';

import {MaterialModule} from '../shared/material/material.module';
import {DirectiveModule} from './directive/directive.module';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, MaterialModule, DirectiveModule],
  exports: [CommonModule, ReactiveFormsModule, MaterialModule, DirectiveModule],
  declarations: []
})
export class SharedModule {}
