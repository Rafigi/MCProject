import { Component, OnInit, Input } from '@angular/core';
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
  showRouteWhenCreated: Boolean = false;
  showCreateRouteCard: boolean = false;



  //Input & Output
  @Input() addRoute: string;


  /** create-event-card ctor */
  constructor() {


  }

  ngOnInit() {
    this.SetPickTimerAndDateTimer();
  }

  //Metodes
  //TODO: Need to do the right thing!
  CreateEvent() {
    console.log("Event Created");
  }

  AddOrChangeRoute() {
    console.log("Event ");
  }

  ShowCreatRouteCard() {
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
