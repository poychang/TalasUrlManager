import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {ServiceWorkerModule} from '@angular/service-worker';

import {environment} from '../environments/environment';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MyMaterialModule} from './shared/my-material.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule, AppRoutingModule, NoopAnimationsModule, MyMaterialModule,
    ServiceWorkerModule.register(
        '/ngsw-worker.js', {enabled: environment.production})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
