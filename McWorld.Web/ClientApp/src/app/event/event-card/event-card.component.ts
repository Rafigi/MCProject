import { Component } from '@angular/core';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.scss']
})
/** EventCard component*/
export class EventCardComponent {
  btntext: string = "Show Event";

  constructor() {

  }
}
