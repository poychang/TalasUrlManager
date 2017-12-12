import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ValidateHttpUrl} from '../../shared/validator/validate-http-url';

@Component({
  selector: 'app-shorten-input-section',
  templateUrl: './shorten-input-section.component.html',
  styleUrls: ['./shorten-input-section.component.scss']
})
export class ShortenInputSectionComponent implements OnInit {
  form: FormGroup;
  shortenDomain = 'shorten.domain/';

  constructor(private formBuilder: FormBuilder) { this.createForm(); }

  ngOnInit() {}
  createForm() {
    this.form = this.formBuilder.group(
      { originUrl: ['', [Validators.required, ValidateHttpUrl]] },
    );
  }
  generate() { console.log(`產生 ${this.form.controls['originUrl'].value} 的短網址`); }
}
