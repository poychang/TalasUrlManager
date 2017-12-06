import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppComponent} from './app.component';
import {DefaultComponent} from './pages/default/default.component';

const routes: Routes = [
  {path: '', component: DefaultComponent},
  {path: '**', redirectTo: '/', pathMatch: 'full'}
];

@NgModule({imports: [RouterModule.forRoot(routes)], exports: [RouterModule]})
export class AppRoutingModule {}
