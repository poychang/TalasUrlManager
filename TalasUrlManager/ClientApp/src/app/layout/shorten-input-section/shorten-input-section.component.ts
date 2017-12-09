import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-shorten-input-section',
  templateUrl: './shorten-input-section.component.html',
  styleUrls: ['./shorten-input-section.component.scss']
})
export class ShortenInputSectionComponent implements OnInit {
  form: FormGroup;
  shortenDomain = 'shorten.domain/';

  constructor(private formBuilder: FormBuilder) { this.createForm(); }

  ngOnInit() {
    // this.form.get('originUrl').valueChanges.pipe()
  }
  createForm() {
    const urlRegex =
      /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/;
    this.form = this.formBuilder.group(
      { originUrl: ['', [Validators.required, Validators.pattern(urlRegex)]] },
    );
  }
  generate() { console.log(`產生 ${this.form.controls['originUrl'].value} 的短網址`); }
}
