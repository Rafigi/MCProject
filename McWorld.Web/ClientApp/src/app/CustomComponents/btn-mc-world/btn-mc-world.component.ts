import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-btn-mc-world',
  templateUrl: './btn-mc-world.component.html',
  styleUrls: ['./btn-mc-world.component.scss']
})
/** BtnMcWorld component*/
export class BtnMcWorldComponent {

  @Input() btnText: string;
  @Input() btnWidth: string;

  constructor() {

  }
}
