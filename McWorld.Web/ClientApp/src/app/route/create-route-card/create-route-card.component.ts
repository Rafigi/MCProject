import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-create-route-card',
    templateUrl: './create-route-card.component.html',
    styleUrls: ['./create-route-card.component.scss']
})
/** create-route-card component*/
export class CreateRouteCardComponent {
  AddORChangeRoute: string;
  private ferry: boolean = false;
  private toll: boolean = false;
  private motorway: boolean = false;

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

  //TODO: Need to do the right thing!
  CreateOrAddRoute() {
    if (this.AddORChangeRoute === "Add Route") {
      console.log("Add route")
    }
    if (this.AddORChangeRoute === "Create Route") {
      console.log("Create route")
    }
  }


  //Switch to select som thing for the route.
  MotorwaySwitch(value) {
    this.motorway = value;
  }
  TollSwitch(value) {
    this.toll = value;
  }
  FerrySwitch(value) {
    this.ferry = value;
  }
}
