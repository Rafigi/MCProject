import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-edit-information-modal',
  templateUrl: './edit-information-modal.component.html',
  styleUrls: ['./edit-information-modal.component.scss']
})
/** Edit-Information-Modal component*/
export class EditInformationModalComponent {
  @Input() hidden: boolean;
  @Output() toggled: EventEmitter<boolean> = new EventEmitter();

  /** Edit-Information-Modal ctor */
  constructor() {

  }

  onClick() {
    this.hidden = !this.hidden
    this.toggled.emit(this.hidden);
  }
}

