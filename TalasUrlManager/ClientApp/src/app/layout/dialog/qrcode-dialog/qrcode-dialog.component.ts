import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material';
import {ShortenDataModel} from '../../../core/models/shorten-data.model';

@Component({
  selector: 'app-qrcode-dialog',
  templateUrl: './qrcode-dialog.component.html',
  styleUrls: ['./qrcode-dialog.component.scss']
})
export class QrcodeDialogComponent implements OnInit {
  url = `${this.baseShortUrl}/${this.data.shortUrl}`;
  qrcodeUrl = `${this.api}/QrCode?size=300&content=${this.baseShortUrl}/${this.data.shortUrl}`;

  constructor(@Inject(MAT_DIALOG_DATA) private data: ShortenDataModel,
              @Inject('baseShortUrl') private baseShortUrl: string,
              @Inject('api') private api: string) {}

  ngOnInit() {}
}
