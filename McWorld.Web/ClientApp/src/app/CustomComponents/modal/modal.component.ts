import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.scss']
})
/** Modal component*/
export class ModalComponent {
  @Input() hidden: boolean;
  @Input() modalWidth: string;

    /** Modal ctor */
    constructor() {

  }

}
