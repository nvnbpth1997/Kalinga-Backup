import { Dash2Component } from './dash2/dash2.component';
import { Dash1Component } from './dash1/dash1.component';
import { DashComponent } from './dash/dash.component';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';


const appRoutes: Routes = [
  {path: '', redirectTo: '/Home', pathMatch: 'full' },
  {path: 'Home', component: DashComponent },
  {path: 'Repeated-Defaulter', component: Dash1Component },
  {path: 'Mind-Details', component: Dash2Component },
  {path: '**', component: Dash1Component }
 ];


@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
