import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.scss']
})
/** Modal component*/
export class ModalComponent {
  @Input() hidden: boolean;
  @Output() toggled: EventEmitter<boolean> = new EventEmitter();
  @Input() modalWidth: string;

    /** Modal ctor */
    constructor() {

  }
  onClick() {
    this.hidden = !this.hidden
    this.toggled.emit(this.hidden);
  }
}
