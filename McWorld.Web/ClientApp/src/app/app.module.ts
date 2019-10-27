import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatIconRegistry, MatIconModule } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { GooglePlaceModule } from "ngx-google-places-autocomplete";

/*Components*/
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
//Event
import { CreateEventCardComponent } from './event/create-event-card/create-event-card.component';
import { EventCardComponent } from './event/event-card/event-card.component';
import { EventListComponent } from './event/event-list/event-list.component';
//Route
import { CreateRouteCardComponent } from './route/create-route-card/create-route-card.component';

//Custom Components
import { ToggleComponent } from './CustomComponents/toggle/toggle.component';
import { SwitchComponent } from './CustomComponents/switch/switch.component';
import { BtnMcWorldComponent } from './CustomComponents/btn-mc-world/btn-mc-world.component';
import { ModalComponent } from './CustomComponents/modal/modal.component';
import { InvisibleCardComponent } from './CustomComponents/invisible-card/invisible-card.component';

import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    ToggleComponent,
    SwitchComponent,
    BtnMcWorldComponent,
    EventCardComponent,
    EventListComponent,
    CreateEventCardComponent,
    CreateRouteCardComponent,
    InvisibleCardComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatIconModule,
    MatSlideToggleModule,
    FormsModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    GooglePlaceModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})


export class AppModule {
  constructor(matIconRegistry: MatIconRegistry, domSanitizer: DomSanitizer) {
    matIconRegistry.addSvgIconSet(domSanitizer.bypassSecurityTrustResourceUrl('./assets/mdi.svg'));
  }
}
