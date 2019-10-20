import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import Event from '../Event';
import Flatpickr from "flatpickr";

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


  //Getting the Event object back from the CreateRouteCard through a Output event.emit(); 
  getRouteFromRouteCard(event: Event) {
    this._showCreateRouteCard = false;
    this._showRouteWhenCreated = true;
    this._$event = event;
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
