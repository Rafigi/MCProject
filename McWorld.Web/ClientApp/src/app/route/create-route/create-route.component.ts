import { Component } from '@angular/core';

@Component({
  selector: 'app-create-route',
  templateUrl: './create-route.component.html',
  styleUrls: ['./create-route.component.scss']
})
/** CreateRoute component*/
export class CreateRouteComponent {

  btntext: string = "Create Route";
  private ferry: boolean = false;
  private toll: boolean = false;
  private motorway: boolean = false;

  constructor() {

  }

  //TODO: Need to do the right thing!
  public CreateRoute() {
    console.log("Route Created");
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
