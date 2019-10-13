import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Components
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './route/create-route/create-route.component';
import { CreateEventComponent } from './event/create-event/create-event.component';
import { EventListComponent } from './event/event-list/event-list.component';


const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {
    path: 'event',
    children: [
      {
        path: 'create',
        component: CreateEventComponent
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
