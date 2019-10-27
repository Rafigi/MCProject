import { Component, Output, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
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
export class CreateRouteCardComponent implements OnInit {
  //Variables
  addORChangeRoute: string;
  _ferry: boolean = false;
  _toll: boolean = false;
  _motorway: boolean = false;
  _startAddress: Address;
  _endAddress: Address;
  private _route: Route;

  options = {
    types: [],
    componentRestrictions: { country: 'DK' },
  }

  @Output() AddRoute = new EventEmitter();
  @Input() $event: Event;

  /** create-route-card ctor */
  constructor(private router: Router) { }

  public handleStartAddressChange(address: any) {
    let addressArray: Array<any>[] = address['address_components'];
    console.log(addressArray);
    if (addressArray.length <= 3) {
      this._startAddress = {
        AddressId: null,
        StreetName: addressArray[2]['long_name'],
        StreetNumber: null,
        City: null,
        Zipcode: parseInt(addressArray[1]['long_name']),
        Country: addressArray[0]['long_name'],
        Latitude: '00000',
        Longitude: '00000'

      }
    }

    if (addressArray.length >= 3) {
      this._startAddress = {
        AddressId: null,
        StreetName: addressArray[1]['long_name'],
        StreetNumber: addressArray[0]['long_name'],
        City: addressArray[3]['long_name'],
        Zipcode: parseInt(addressArray[4]['long_name']),
        Country: addressArray[3]['long_name'],
        Latitude: '00000',
        Longitude: '00000'
      }
    }
  }


  public handleEndAddressChange(address: any) {
    let addressArray: Array<any>[] = address['address_components'];
    if (addressArray.length <= 3) {
      this._endAddress = {
        AddressId: null,
        StreetName: addressArray[2]['long_name'],
        StreetNumber: null,
        City: null,
        Zipcode: parseInt(addressArray[1]['long_name']),
        Country: addressArray[0]['long_name'],
        Latitude: '00000',
        Longitude: '00000'

      }
    }

    if (addressArray.length >= 3) {
      this._endAddress = {
        AddressId: null,
        StreetName: addressArray[1]['long_name'],
        StreetNumber: addressArray[0]['long_name'],
        City: addressArray[3]['long_name'],
        Zipcode: parseInt(addressArray[4]['long_name']),
        Country: addressArray[3]['long_name'],
        Latitude: '00000',
        Longitude: '00000'
      }
    }
}

ngOnInit() {
  this.UrlCheck();
  if (this.$event != undefined) {
    this.IsRouteDefined(this.$event);
  }
  this._route = new Route();
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
    this.$event.UpdateRoute(0, this._ferry, this._toll, this._motorway, this._startAddress, this._endAddress);
    this.AddRoute.emit(this.$event);
  }

  if (this.addORChangeRoute === "Create Route") {
    this._route.CreateRoute(0, this._ferry, this._toll, this._motorway, this._startAddress, this._endAddress);
  }
}

GlueAddressTogether() {
  let start = this.$event.Route.Addresses[0];
  let end = this.$event.Route.Addresses[1];
  //this._startAddress = start.StreetName + " " + start.StreetNumber + ", " + start.Zipcode + " " + start.City;
  //this._endAddress = end.StreetName + " " + end.StreetNumber + ", " + end.Zipcode + " " + end.City
}


//SplitAddress(address: string): Address {

//  //Returning the object as it should be
//  return {
//    AddressId: null,
//    StreetName: streetAddressName,
//    StreetNumber: streetNumber,
//    City: city,
//    Zipcode: parseInt(zipCode),
//    Country: 'Denmark',
//    Latitude: '00000',
//    Longitude: '00000'
//  }

//}

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
