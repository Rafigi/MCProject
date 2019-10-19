import { Component, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import Event from '../../event/Event';
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
  private addORChangeRoute: string;
  private _ferry: boolean = false;
  private _toll: boolean = false;
  private _motorway: boolean = false;
  private _startAddress: string;
  private _endAddress: string;

  @Output() AddRoute = new EventEmitter();
  @Input() $event: Event;

  /** create-route-card ctor */
  constructor(private router: Router) { }

  ngOnInit() {
    this.UrlCheck();
    this.IsRouteDefined(this.$event);
  }


  //Reactiveform
  RouteForm = new FormGroup({
    startAddress: new FormControl(''),
    endAddress: new FormControl('')
  });

  //Metodes
  IsRouteDefined(event: Event) {
    if (event.Route != undefined) {
      this._ferry = event.Route.Ferry;
      this._toll = event.Route.Toll;
      this._motorway = event.Route.Motorway;
      this.GlueAddressTogether();
      this.RouteForm.setValue({ startAddress: this._startAddress, endAddress: this._endAddress });
    }
    this.$event.Route = new Route();
  }

  UrlCheck() {
    if (this.router.url === "/event/create") {
      this.addORChangeRoute = "Add Route";
    }
    if (this.router.url === "/route/create") {
      this.addORChangeRoute = "Create Route";
    }
  }

  CreateOrAddRoute() {
    if (this.addORChangeRoute === "Add Route") {
      let startAddress: Address = this.SplitAddress(this.RouteForm.get("startAddress").value);
      let endAddress: Address = this.SplitAddress(this.RouteForm.get("endAddress").value);
      this.$event.UpdateRoute(0, this._ferry, this._toll, this._motorway, startAddress, endAddress);
      console.log(this.$event);
      this.AddRoute.emit(this.$event);
    }
    if (this.addORChangeRoute === "Create Route") {

    }
  }

  GlueAddressTogether() {
    let start = this.$event.Route.Addresses[0];
    let end = this.$event.Route.Addresses[1];
    this._startAddress = start.StreetName + " " + start.StreetNumber + ", " + start.Zipcode + " " + start.City;
    this._endAddress = end.StreetName + " " + end.StreetNumber + ", " + end.Zipcode + " " + end.City
  }


  SplitAddress(address: string): Address {
    console.log(address);
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
