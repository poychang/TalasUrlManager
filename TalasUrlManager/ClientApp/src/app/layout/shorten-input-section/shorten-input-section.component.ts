import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {FormControl} from '@angular/forms/src/model';

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
    const urlRegex =
      /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/;
    this.form = this.formBuilder.group(
      { originUrl: ['', [Validators.required, Validators.pattern(urlRegex)]] });
  }
  getErrorMessage(formControl: FormControl) {
    switch (Object.keys(formControl.errors)[0]) {
      case 'required':
        return '必填欄位';
      case 'pattern':
        return '格式錯誤';
    }
  }
  generate() { console.log(`產生 ${this.form.controls['originUrl'].value} 的短網址`); }
}
