import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';

import {ShortenDataSource} from '../../core/data-source/shorten-data-source';
import {ShortenDataModel} from '../../core/models/shorten-data.model';
import {ConfigurationService} from '../../core/services/configuration.service';
import {ShortenDataService} from '../../core/services/shorten-data.service';
import {ValidateHttpUrl} from '../../shared/validator/validate-http-url';

@Component({
  selector: 'app-shorten-input-section',
  templateUrl: './shorten-input-section.component.html',
  styleUrls: ['./shorten-input-section.component.scss']
})
export class ShortenInputSectionComponent implements OnInit {
  shortUrlBase = this.configService.config.shortUrlBase;
  form: FormGroup;

  constructor(private configService: ConfigurationService,
              private shortenDataService: ShortenDataService) {}

  ngOnInit() { this.createForm(); }
  createForm() {
    this.form = new FormGroup({
      originalUrl: new FormControl(
        '', { validators: [Validators.required, ValidateHttpUrl], updateOn: 'change' })
    });
  }
  generate() {
    const item = {
      originalUrl: this.form.get('originalUrl').value,
    } as ShortenDataModel;
    this.shortenDataService.save(item).subscribe(() => {}, (e) => { console.log(e); });
    this.form.reset();
  }
}
