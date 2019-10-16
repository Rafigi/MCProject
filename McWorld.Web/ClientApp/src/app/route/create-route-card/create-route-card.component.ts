import { Component, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import route from '../Models/Route';

@Component({
  selector: 'app-create-route-card',
  templateUrl: './create-route-card.component.html',
  styleUrls: ['./create-route-card.component.scss']
})
/** create-route-card component*/
export class CreateRouteCardComponent {
  AddORChangeRoute: string;
  private _ferry: boolean = false;
  private _toll: boolean = false;
  private _motorway: boolean = false;
  private _route: route;
  @Output() AddRoute = new EventEmitter();

  /** create-route-card ctor */
  constructor(private router: Router) {
    this.controlUrlRoute();
  }

  controlUrlRoute() {
    if (this.router.url === "/event/create") {
      this.AddORChangeRoute = "Add Route";
    }
    if (this.router.url === "/route/create") {
      this.AddORChangeRoute = "Create Route";
    }
  }


  //Reactiveform
  RouteForm = new FormGroup({
    startAddress: new FormControl(''),
    endAddress: new FormControl('')
  });

  //TODO: Need to do the right thing!
  CreateOrAddRoute() {
    if (this.AddORChangeRoute === "Add Route") {
      this._route = {
        Toll: this._toll,
        Motorway: this._motorway,
        Ferry: this._ferry,
        Distance: null,
        Created: new Date().toLocaleDateString(),
        UserID: undefined,
        RouteID: undefined,
        Addresses: this.RouteForm.get("startAddress").value
      }
      this.AddRoute.emit(this._route);
    }
    if (this.AddORChangeRoute === "Create Route") {
      console.log("Create route")
    }
  }


  //Switch to select som things for the route.
  MotorwaySwitch(value) {
    this._motorway = value;
  }
  TollSwitch(value) {
    this._toll = value;
  }
  FerrySwitch(value) {
    this._ferry = value;
  }
}
