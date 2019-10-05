import { Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-btn-mc-world',
  template: `<button class="CreateBtn">
      <p>{{ btnText }}</p>
      </button>`,
  styleUrls: ['./btn-mc-world.component.scss']
})
/** BtnMcWorld component*/
export class BtnMcWorldComponent {
  @Input() btnText: string;
  constructor() {

  }
}
