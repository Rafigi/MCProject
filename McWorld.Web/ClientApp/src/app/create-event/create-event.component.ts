import { Component, OnInit } from '@angular/core';
import Flatpickr from "flatpickr";

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
/** CreateEvent component*/
export class CreateEventComponent implements OnInit {

  btnAdd: string = "Add Route";
  btnCreate: string = "Create Event";
  constructor() {


  }

  ngOnInit() {
    this.SetPickTimerAndDateTimer();
  }

  //Metodes
  TimeOfDay(): string {
    var hour = new Date().getHours();
    var minut = new Date().getMinutes();
    return hour + ":" + minut;
  }

  //TODO: Need to do the right thing!
  public CreateEvent() {
    console.log("Event Created");
  }


  DateOfDay(): string {
    return new Date().toLocaleDateString();
  }

  SetPickTimerAndDateTimer() {
    Flatpickr("#startTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true,
      defaultDate: this.TimeOfDay()
    });

    Flatpickr("#startDatetime", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      defaultDate: this.DateOfDay()
    });

    Flatpickr("#endTime", {
      enableTime: true,
      noCalendar: true,
      dateFormat: "H:i",
      time_24hr: true,
      defaultDate: this.TimeOfDay()
    });

    Flatpickr("#endDatetime", {
      altInput: false,
      altFormat: "F j, Y",
      dateFormat: "d.m.Y",
      minDate: "today",
      defaultDate: this.DateOfDay()
    });
  }



}
