import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {MatSnackBar} from '@angular/material';

import {ShortenDataModel} from '../../core/models/shorten-data.model';
import {ValidateHttpUrl} from '../../shared/validator/validate-http-url';

@Component({
  selector: 'app-shorten-form',
  templateUrl: './shorten-form.component.html',
  styleUrls: ['./shorten-form.component.scss']
})
export class ShortenFormComponent implements OnInit, OnDestroy {
  @Input() formData = {} as ShortenDataModel;
  form: FormGroup;

  constructor() {}

  ngOnInit() {
    console.log(this.formData);

    this.form = new FormGroup({
      shortUrl: new FormControl('', { validators: [Validators.required], updateOn: 'change' }),
      customizeUrl: new FormControl('', { validators: [], updateOn: 'change' }),
      originalUrl: new FormControl(
        '', { validators: [Validators.required, ValidateHttpUrl], updateOn: 'change' }),
      expireDate: new FormControl('', { validators: [], updateOn: 'change' }),
      isActivate: new FormControl(true, { validators: [Validators.required], updateOn: 'change' }),
    });
  }
  ngOnDestroy() { this.reset(); }
  save() { console.log('save'); }
  cancel() { console.log('cancel'); }
  reset() { this.form.reset(); }
}
