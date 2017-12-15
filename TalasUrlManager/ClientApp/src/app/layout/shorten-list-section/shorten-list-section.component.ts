import {AfterViewInit, Component, Inject, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorIntl, MatSort, PageEvent} from '@angular/material';

import {ShortenDataSource} from '../../core/data-source/shorten-data-source';
import {ShortenDataModel} from '../../core/models/shorten-data.model';

@Component({
  selector: 'app-shorten-list-section',
  templateUrl: './shorten-list-section.component.html',
  styleUrls: ['./shorten-list-section.component.scss']
})
export class ShortenListSectionComponent implements OnInit, AfterViewInit {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: ShortenDataSource;
  displayedColumns = [
    'id',
    'shortUrl',
    'customizeUrl',
    'originalUrl',
    'expireDate',
    'clicks',
    'isActive',
    'utility'
  ];

  constructor(@Inject('baseShortUrl') public baseShortUrl: string,
              private paginatorIntl: MatPaginatorIntl,
              private shortenDataSource: ShortenDataSource) {
    this.dataSource = this.shortenDataSource;
  }

  ngOnInit() {
    this.paginatorIntl.itemsPerPageLabel = '每頁顯示';
    this.paginatorIntl.nextPageLabel = '下一頁';
    this.paginatorIntl.previousPageLabel = '上一頁';
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.dataSource.paginator.page.subscribe((pageInfo: PageEvent) => {
      if (pageInfo.pageIndex === Math.round(pageInfo.length / pageInfo.pageSize)) {
        this.dataSource.fetchMoreData();
      }
    });
  }
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();        // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }
  openEditDialog(ele: ShortenDataModel) { console.log('Edit', ele); }
  openQrCodeDialog(ele: ShortenDataModel) { console.log('QrCode', ele); }
}
