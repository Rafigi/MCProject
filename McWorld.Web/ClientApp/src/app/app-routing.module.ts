import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Components
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './create-route/create-route.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { EventCardComponent } from './event-card/event-card.component';
import { EventListComponent } from './event-list/event-list.component';


const appRoutes: Routes = [
  { path: 'create-route', component: CreateRouteComponent },
  { path: 'create-event', component: CreateEventComponent },
  { path: 'home', component: HomeComponent },
  { path: 'eventcard', component: EventCardComponent },
  { path: 'events', component: EventListComponent },
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
