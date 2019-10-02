import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatIconRegistry, MatIconModule } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { HomeComponent } from './home/home.component';
import { CreateRouteComponent } from './create-route/create-route.component';
import { ToggleComponent } from './CustomComponents/toggle/toggle.component';
import { SwitchComponent } from './CustomComponents/switch/switch.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreateRouteComponent,
    ToggleComponent,
    SwitchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatIconModule,
    MatSlideToggleModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CreateRouteComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(matIconRegistry: MatIconRegistry, domSanitizer: DomSanitizer) {
    matIconRegistry.addSvgIconSet(domSanitizer.bypassSecurityTrustResourceUrl('./assets/mdi.svg'));
  }
}
