import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import Route from '../Models/Route';
import Address from '../Models/Address';

@Component({
  selector: 'app-create-route-card',
  templateUrl: './create-route-card.component.html',
  styleUrls: ['./create-route-card.component.scss']
})
/** create-route-card component*/
export class CreateRouteCardComponent {
  //Variables
  AddORChangeRoute: string;
  private _ferry: boolean = false;
  private _toll: boolean = false;
  private _motorway: boolean = false;
  private _startAddress: string;
  private _endAddress: string;


  @Output() AddRoute = new EventEmitter();
  @Input() _route: Route;

  /** create-route-card ctor */
  constructor(private router: Router) {
    this.controlUrlRoute();
  }

  ngOnInit() {
    if (this._route != undefined) {
      this._ferry = this._route.Ferry;
      this._toll = this._route.Toll;
      this._motorway = this._route.Motorway;
      this.GlueAddressTogether();
      this.RouteForm.setValue({ startAddress: this._startAddress, endAddress: this._endAddress });
    }
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

  CreateOrAddRoute() {
    if (this.AddORChangeRoute === "Add Route") {

      this._route = {
        Toll: this._toll,
        Motorway: this._motorway,
        Ferry: this._ferry,
        Distance: null,
        Created: undefined,
        UserID: undefined,
        RouteID: undefined,
        Addresses: [
          this.SplitAddress(this.RouteForm.get("startAddress").value),
          this.SplitAddress(this.RouteForm.get("endAddress").value)]
      }

      this.AddRoute.emit(this._route);
    }
    if (this.AddORChangeRoute === "Create Route") {
      console.log("Create route")
    }
  }

  GlueAddressTogether() {
    let start = this._route.Addresses[0];
    let end = this._route.Addresses[1];
    this._startAddress = start.StreetName + " " + start.StreetNumber + ", " + start.Zipcode + " " + start.City;
    this._endAddress = end.StreetName + " " + end.StreetNumber + ", " + end.Zipcode + " " + end.City
  }


  SplitAddress(address: string): Address {

    let splittedAddress = address.split(",");
    let streetAddressWithNumber = splittedAddress[0].split(" ");
    //Address
    let streetAddressName = streetAddressWithNumber[0];
    let streetNumber = streetAddressWithNumber[1];

    //City Because it dotn delete the first array element, we have to start from 1. 0 is a empty string
    let zipCodeWithCity = splittedAddress[1].split(" ");
    let zipCode = zipCodeWithCity[1];
    let city = zipCodeWithCity[2];

    //Returning the object as it should be
    return {
     AddressId: null,
     StreetName: streetAddressName,
     StreetNumber: streetNumber,
     City: city,
     Zipcode: parseInt(zipCode),
     Country: 'Denmark',
     Latitude: '00000',
     Longitude: '00000'
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
