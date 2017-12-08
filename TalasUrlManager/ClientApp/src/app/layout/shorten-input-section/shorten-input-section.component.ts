import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shorten-input-section',
  templateUrl: './shorten-input-section.component.html',
  styleUrls: ['./shorten-input-section.component.scss']
})
export class ShortenInputSectionComponent implements OnInit {
  shortenDomain = 'shorten.domain/';

  constructor() { }

  ngOnInit() {
  }

}
