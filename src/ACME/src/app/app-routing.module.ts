import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ApplicationComponent } from './application/application.component';


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'application'},
  { path: 'application', component: ApplicationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }