import { Component, Output, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import Event from '../../event/Event';
import Route from '../Models/Route';
import Address from '../Models/Address';

declare const google;

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

  FormattedStartAddress: string = "";
  formattedEndAddress: string = "";

  options = {
    types: [],
    componentRestrictions: { country: 'DK' },
  }

  @Output() AddRoute = new EventEmitter();
  @Input() $event: Event;

  /** create-route-card ctor */
  constructor(private router: Router) { }

  ngOnInit() {
    this.UrlCheck();
    if (this.$event != undefined) {
      this.IsRouteDefined(this.$event);
    }
    this._route = new Route();
  }

  CreateGoogleMap() {
    var myOptions = {
      zoom: 10,
      center: new google.maps.LatLng(55.84, 9.25),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    // Draw the map
    var mapObject = new google.maps.Map(document.getElementById("map"), myOptions);

    var directionsService = new google.maps.DirectionsService();
    var directionsRequest = {
      origin: this.FormattedStartAddress,
      destination: this.formattedEndAddress,
      travelMode: google.maps.DirectionsTravelMode.DRIVING,
      unitSystem: google.maps.UnitSystem.METRIC,
      avoidHighways: this._motorway,
      avoidFerries: this._ferry,
      avoidTolls: this._toll
    };

    directionsService.route(
      directionsRequest,
      function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
          new google.maps.DirectionsRenderer({
            map: mapObject,
            directions: response
          });
        }
        else
          console.log("Crap");
      }
    );


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

  public handleStartAddressChange(address: any) {
    console.log(address["formatted_address"]);
    this.FormattedStartAddress = address["formatted_address"];
    this.CreateGoogleMap();
    let addressArray: Array<any>[] = address['address_components'];
    console.log(address);
    if (addressArray.length >= 5) {
      this._startAddress = {
        AddressId: null,
        StreetName: addressArray[1]['long_name'],
        StreetNumber: addressArray[0]['long_name'],
        City: addressArray[2]['long_name'],
        Zipcode: parseInt(addressArray[4]['long_name']),
        Country: addressArray[3]['long_name'],
        Latitude: '00000',
        Longitude: '00000'
      }
    }
  }

  public handleEndAddressChange(address: any) {
    this.formattedEndAddress = address["formatted_address"];
    this.CreateGoogleMap();
    let addressArray: Array<any>[] = address['address_components'];
    if (addressArray.length >= 5) {
      this._endAddress = {
        AddressId: null,
        StreetName: addressArray[1]['long_name'],
        StreetNumber: addressArray[0]['long_name'],
        City: addressArray[2]['long_name'],
        Zipcode: parseInt(addressArray[4]['long_name']),
        Country: addressArray[3]['long_name'],
        Latitude: '00000',
        Longitude: '00000'
      }
    }
  }

  //Switch to select som things for the route.
  MotorwaySwitch(value) {
    this._motorway = value;
    this.CreateGoogleMap();
  }
  TollSwitch(value) {
    this._toll = value;
    this.CreateGoogleMap();
  }
  FerrySwitch(value) {
    this._ferry = value;
    this.CreateGoogleMap();
  }
}
