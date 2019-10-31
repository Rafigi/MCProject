import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import Event from '../Event';
import Flatpickr from "flatpickr";

declare const google;

@Component({
  selector: 'app-create-event-card',
  templateUrl: './create-event-card.component.html',
  styleUrls: ['./create-event-card.component.scss']
})
/** create-event-card component*/
export class CreateEventCardComponent implements OnInit {
  //Variables
  btnAddorChangeRoute: string = "Add Route";
  _showRouteWhenCreated: boolean = false;
  _showCreateRouteCard: boolean = false;
  private _$event: Event;

  /** create-event-card ctor */
  constructor(private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.GenerateEventObject();
    this.ref.detectChanges();
    this.SetPickTimerAndDateTimer();

  }

  CreateGoogleMap() {
    var myOptions = {
      zoom: 1,
      center: new google.maps.LatLng(55.84, 9.25),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    // Draw the map
    var mapObject = new google.maps.Map(document.getElementById("map"), myOptions);

    var directionsService = new google.maps.DirectionsService();
    var directionsRequest = {
      origin: this.ConvertAddressToStringWithIndex(0),
      destination: this.ConvertAddressToStringWithIndex(1),
      travelMode: google.maps.DirectionsTravelMode.DRIVING,
      unitSystem: google.maps.UnitSystem.METRIC,
      avoidHighways: this._$event.Route.Motorway,
      avoidFerries: this._$event.Route.Ferry,
      avoidTolls: this._$event.Route.Toll
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


  ConvertAddressToStringWithIndex(index: number): string {
    let addressString = this._$event.Route.Addresses[index].StreetName
      + " " +
      this._$event.Route.Addresses[index].StreetNumber
      + ", " +
      this._$event.Route.Addresses[index].Zipcode
      + " " +
      this._$event.Route.Addresses[index].City;
    return addressString;
  }



  //Getting the Event object back from the CreateRouteCard through a Output event.emit(); 
  getRouteFromRouteCard(event: Event) {
    this._showCreateRouteCard = false;
    this._showRouteWhenCreated = true;
    this._$event = event;
    this.CreateGoogleMap();
    this.btnAddorChangeRoute = 'Change Route';
  }

  EventForm = new FormGroup({
    headline: new FormControl(''),
    description: new FormControl(''),
    startDate: new FormControl(''),
    startTime: new FormControl(''),
    endDate: new FormControl(''),
    endTime: new FormControl('')
  });

  //Metodes
  CreateEvent() {
    //let eventCreated = this._event.Created(this._event);
    console.log("Event Created and sent to DATABASE");
  }

  //Creating a Event Object, with some default values and setting the inputs
  GenerateEventObject() {
    this._$event = new Event();
    this.EventForm.setValue({
      headline: this._$event.Headline,
      description: this._$event.Description,
      startDate: this._$event.StartDate,
      startTime: this._$event.StartTime,
      endDate: this._$event.EndDate,
      endTime: this._$event.EndTime
    });
  }

  ShowCreateRouteCard() {
    this._$event.UpdateEvent(
      this.EventForm.get("headline").value,
      this.EventForm.get("description").value,
      this.EventForm.get("startDate").value,
      this.EventForm.get("startTime").value,
      this.EventForm.get("endDate").value,
      this.EventForm.get("endTime").value
    );
    this._showCreateRouteCard = true;
  }

  //Setting the date/time inputs 
  SetPickTimerAndDateTimer() {
    Flatpickr("#startTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true
    });

    Flatpickr("#startDate", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      weekNumbers: true
    });

    Flatpickr("#endTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true
    });

    Flatpickr("#endDate", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      weekNumbers: true
    });

  }
}
