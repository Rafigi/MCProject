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
  btnAddRoute: string = "Add Route";
  btnCreateEvent: string = "Create Event";
  _showRouteWhenCreated: boolean = false;
  _showCreateRouteCard: boolean = false;
  private _event: Event;

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
    this._event = event;
    this.btnAddRoute = 'Change Route';
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
    this._event = new Event();
    this.EventForm.setValue({
      headline: this._event.Headline,
      description: this._event.Description,
      startDate: this._event.StartDate,
      startTime: this._event.StartTime,
      endDate: this._event.EndDate,
      endTime: this._event.EndTime
    });
  }

  ShowCreateRouteCard() {
    this._event.UpdateEvent(
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
