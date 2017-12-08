import {NgModule} from '@angular/core';
import {MatButtonModule, MatIconModule, MatInputModule, MatSidenavModule, MatToolbarModule} from '@angular/material';

@NgModule({
  imports: [
    MatButtonModule, MatIconModule, MatInputModule, MatSidenavModule,
    MatToolbarModule
  ],
  exports: [
    MatButtonModule, MatIconModule, MatInputModule, MatSidenavModule,
    MatToolbarModule
  ],
})
export class MyMaterialModule {}
