import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
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
  @Input() addRoute: string;


  /** create-event-card ctor */
  constructor(private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.ref.detectChanges();
    this.SetPickTimerAndDateTimer();
  }

  //Metodes
  //TODO: Need to do the right thing!
  CreateEvent() {
    console.log("Event Created");
  }

  AddOrChangeRoute() {
    this.showCreateRouteCard = false;
  }

  ShowCreateRouteCard() {
    this.showCreateRouteCard = true;
  }


  SetPickTimerAndDateTimer() {
    Flatpickr("#startTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true,
      defaultDate: this.SetTimeOfDay()
    });

    Flatpickr("#startDatetime", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      defaultDate: this.SetDateOfDay()
    });

    Flatpickr("#endTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true,
      defaultDate: this.SetTimeOfDay()
    });

    Flatpickr("#endDatetime", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      defaultDate: this.SetDateOfDay()
    });
  }

  SetTimeOfDay(): string {
    var hour = new Date().getHours();
    var minut = new Date().getMinutes();
    return hour + ":" + minut;
  }

  SetDateOfDay(): string {
    return new Date().toLocaleDateString();
  }
}
