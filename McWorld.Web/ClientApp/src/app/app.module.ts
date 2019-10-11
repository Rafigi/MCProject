import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatIconRegistry, MatIconModule } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//Components
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './create-route/create-route.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { EventCardComponent } from './event-card/event-card.component';
import { EventListComponent } from './event-list/event-list.component';

//Custom Components
import { ToggleComponent } from './CustomComponents/toggle/toggle.component';
import { SwitchComponent } from './CustomComponents/switch/switch.component';
import { BtnMcWorldComponent } from './CustomComponents/btn-mc-world/btn-mc-world.component';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    CreateRouteComponent,
    CreateEventComponent,
    ToggleComponent,
    SwitchComponent,
    BtnMcWorldComponent,
    EventCardComponent,
    EventListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatIconModule,
    MatSlideToggleModule,
    FormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})


export class AppModule {
  constructor(matIconRegistry: MatIconRegistry, domSanitizer: DomSanitizer) {
    matIconRegistry.addSvgIconSet(domSanitizer.bypassSecurityTrustResourceUrl('./assets/mdi.svg'));
  }
}
