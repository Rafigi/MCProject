import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Components
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './create-route/create-route.component';
import { CreateEventComponent } from './create-event/create-event.component';


const appRoutes: Routes = [
  { path: 'route', component: CreateRouteComponent },
  { path: 'event', component: CreateEventComponent },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
