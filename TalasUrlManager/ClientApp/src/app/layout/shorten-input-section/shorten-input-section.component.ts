import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';

import {ValidateHttpUrl} from '../../shared/validator/validate-http-url';

@Component({
  selector: 'app-shorten-input-section',
  templateUrl: './shorten-input-section.component.html',
  styleUrls: ['./shorten-input-section.component.scss']
})
export class ShortenInputSectionComponent implements OnInit {
  form: FormGroup;

  constructor(@Inject('baseShortUrl') public baseShortUrl: string,
              private shortenDataService: ShortenDataService) {}

  ngOnInit() { this.createForm(); }
  createForm() {
    this.form = new FormGroup({
      originalUrl: new FormControl(
        '', { validators: [Validators.required, ValidateHttpUrl], updateOn: 'change' })
    });
  }
  }
  generate() { console.log(`產生 ${this.form.controls['originUrl'].value} 的短網址`); }
}
