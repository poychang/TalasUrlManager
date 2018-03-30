import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';
import {ShortenDataModel} from '../../../core/models/shorten-data.model';
import {ConfigurationService} from '../../../core/services/configuration.service';

@Component({
  selector: 'app-qrcode-dialog',
  templateUrl: './qrcode-dialog.component.html',
  styleUrls: ['./qrcode-dialog.component.scss']
})
export class QrcodeDialogComponent implements OnInit {
  config = this.configService.config;
  url = `${this.config.shortUrlBase}${this.data.shortUrl}`;
  qrcodeUrl = `${this.api}/QrCode/${this.data.id}`;

  constructor(@Inject(MAT_DIALOG_DATA) private data: ShortenDataModel,
              @Inject('api') private api: string,
              private configService: ConfigurationService) {}

  ngOnInit() {}
}
