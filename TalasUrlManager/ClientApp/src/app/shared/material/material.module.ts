import {NgModule} from '@angular/core';
import {
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatPaginatorModule,
  MatSidenavModule,
  MatSortModule,
  MatTableModule,
  MatToolbarModule
} from '@angular/material';

@NgModule({
  imports: [
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatSidenavModule,
    MatSortModule,
    MatTableModule,
    MatToolbarModule
  ],
  exports: [
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatSidenavModule,
    MatSortModule,
    MatTableModule,
    MatToolbarModule
  ],
})
export class MaterialModule {}
