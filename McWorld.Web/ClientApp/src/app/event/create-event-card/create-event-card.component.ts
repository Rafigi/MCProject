import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import event from '../Event';
import route from '../../route/Models/Route';
import Flatpickr from "flatpickr";

@Component({
  selector: 'app-create-event-card',
  templateUrl: './create-event-card.component.html',
  styleUrls: ['./create-event-card.component.scss']
})
/** create-event-card component*/
export class CreateEventCardComponent implements OnInit {
  //Variables
  btnAddRoute: string = "Add Route";
  btnCreateEvent: string = "Create Event";
  _showRouteWhenCreated: boolean = false;
  _showCreateRouteCard: boolean = false;
  private _route: route;
  private _event: event = null;

  //Input & Output


  /** create-event-card ctor */
  constructor(private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.ref.detectChanges();
    this.SetPickTimerAndDateTimer();
  }

  getRoute(route) {
    this._showCreateRouteCard = false;
    this._showRouteWhenCreated = true;
    this._route = route;
    console.log(this._route);
    this.btnAddRoute = 'Change Route';

  }


  //Reactiveform
  EventForm = new FormGroup({
    headline: new FormControl(''),
    description: new FormControl(''),
    startDateTime: new FormControl(new Date().toLocaleDateString()),
    startTime: new FormControl(this.SetTimeOfTheDay()),
    endDateTime: new FormControl(new Date().toLocaleDateString()),
    endTime: new FormControl(this.SetTimeWithOneMoreHour())
  });


  //Metodes
  //TODO: Need to do the right thing!
  CreateEvent() {
    console.log(this.EventForm.value);
  }

  ShowCreateRouteCard() {
    this._showCreateRouteCard = true;
  }

  //Set the date
  SetPickTimerAndDateTimer() {
    Flatpickr("#startTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true
    });

    Flatpickr("#startDatetime", {
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

    Flatpickr("#endDatetime", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      weekNumbers: true
    });

  }

  SetTimeOfTheDay(): string {
    var hour = new Date().getHours();
    var minut = new Date().getMinutes();
    return hour + ":" + minut;
  }


  SetTimeWithOneMoreHour(): string {
    var hour = new Date().getHours();
    var minut = new Date().getMinutes();
    return hour + 1 + ":" + minut;
  }
}
