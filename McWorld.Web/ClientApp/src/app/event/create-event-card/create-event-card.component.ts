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
  btnAdd: string = "Add Route";
  btnchangeRoute: string = "Change Route";
  btnCreate: string = "Create Event";

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

  AddRoute() {
    console.log("Event ");
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
