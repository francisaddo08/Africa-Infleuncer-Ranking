import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from '@angular/material/card';
import {FormsModule} from '@angular/forms'

import { HttpClientModule } from '@angular/common/http';
import { GoogleMapsModule } from '@angular/google-maps';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from './home/home.component';
import { MapLocationComponent } from './map-location/map-location.component';
import { DataService } from './data.service';
import { FooterComponent } from './footer/footer.component';
import { LargeTabletComponent } from './large-tablet/large-tablet.component';
import { AdminComponent } from './admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    MapLocationComponent,
    FooterComponent,
    LargeTabletComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,

    GoogleMapsModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    MatCardModule,
    FormsModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent],
})
export class AppModule {}
