import {AfterViewInit, Component, Inject, OnInit, ViewChild} from '@angular/core';
import {MatDialog, MatPaginator, MatPaginatorIntl, MatSort, PageEvent} from '@angular/material';

import {ShortenDataSource} from '../../core/data-source/shorten-data-source';
import {ShortenDataModel} from '../../core/models/shorten-data.model';
import {QrcodeDialogComponent} from '../dialog/qrcode-dialog/qrcode-dialog.component';

@Component({
  selector: 'app-shorten-list-section',
  templateUrl: './shorten-list-section.component.html',
  styleUrls: ['./shorten-list-section.component.scss']
})
export class ShortenListSectionComponent implements OnInit, AfterViewInit {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource = this.shortenDataSource;
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
              private shortenDataSource: ShortenDataSource,
              public dialog: MatDialog) {}

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
  openEditDialog(item: ShortenDataModel) { console.log('Edit', item); }
  openQrCodeDialog(item: ShortenDataModel) {
    this.dialog.open(QrcodeDialogComponent, { data: item });
  }
}
