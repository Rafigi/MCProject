import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
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
  btnchangeRoute: string = "Change Route";
  btnCreateEvent: string = "Create Event";
  showRouteWhenCreated: boolean = false;
  showCreateRouteCard: boolean = false;

  //Input & Output


  /** create-event-card ctor */
  constructor(private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.ref.detectChanges();
    this.SetPickTimerAndDateTimer();
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

  AddOrChangeRoute() {
    this.showCreateRouteCard = false;
  }

  ShowCreateRouteCard() {
    this.showCreateRouteCard = true;
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
