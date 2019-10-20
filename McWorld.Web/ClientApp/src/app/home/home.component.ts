import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
/** Home component*/
export class HomeComponent {
  _InfoModalhidden: boolean = false;
  _changePasswordModalhidden: boolean = false;
  _EditEmailModalhidden: boolean = false;
  btnDisabled: boolean = false;
  /** Home ctor */
  constructor() {

  }

  ChangePassword() {
    console.log("Password is changes!");
    this.ShowHideChangePasswordModal();
  }
  CloseChangePassword() {
    this.ShowHideChangePasswordModal();
  }

  EditEmail() {
    console.log("Email is changes!");
    this.ShowHideEditEmailModal();
  }

  CloseEditEmail() {
    this.ShowHideEditEmailModal();
  }

  ShowHideInfoModal() {
    this._InfoModalhidden = !this._InfoModalhidden;
  }

  ShowHideChangePasswordModal() {
    this._changePasswordModalhidden = !this._changePasswordModalhidden;
    this.DisabledInformationButton();
    this.ShowHideInfoModal();
  }

  ShowHideEditEmailModal() {
    this._EditEmailModalhidden = !this._EditEmailModalhidden;
    this.DisabledInformationButton();
    this.ShowHideInfoModal();
  }

  DisabledInformationButton() {
    this.btnDisabled = !this.btnDisabled;
  }
}
