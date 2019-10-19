import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
/** Home component*/
export class HomeComponent {
  _hidden: boolean = false;
  editMail: string = "Edit Mail";
  changePassword: string = "Change Password";
  /** Home ctor */
  constructor() {

  }

  ShowInfoModal() {
    this._hidden = !this._hidden;
  }

  ShowHide(value) {
    this._hidden = value;
  }
}
