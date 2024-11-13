import { DataService } from './../data.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'location',
  templateUrl: './map-location.component.html',
  styleUrls: ['./map-location.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MapLocationComponent implements OnInit {
  rank = 'no data';
  mapOptions!: google.maps.MapOptions;
  constructor(public data: DataService, private router: ActivatedRoute) {}
  ngOnInit() {
    this.mapOptions = {
      center: { lat: this.data.countryLocation.locationLat, lng: this.data.countryLocation.locationLong },
      zoom: 4,
      mapTypeId: google.maps.MapTypeId.TERRAIN,
      

    }


  }
}
