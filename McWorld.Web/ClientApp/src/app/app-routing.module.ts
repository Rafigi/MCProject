import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Components
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './route/create-route/create-route.component';
import { CreateEventCardComponent } from './event/create-event-card/create-event-card.component';
import { EventListComponent } from './event/event-list/event-list.component';


const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {
    path: 'event',
    children: [
      {
        path: 'create',
        component: CreateEventCardComponent
      },
      {
        path: 'all',
        component: EventListComponent
      },
      {
      path: 'addroute',
      component: CreateRouteComponent
      }
    ],
  },
  {
    path: 'route',
    children: [
      {
        path: 'create',
        component: CreateRouteComponent
      }
    ]
  },
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
