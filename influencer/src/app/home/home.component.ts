import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { CountryData, IInfluencer } from 'src/shared/IInfluencer';
import { Router } from '@angular/router';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  num1: any = {};

  constructor(public data: DataService, private router: Router) {
    //console.log(' home componet' + JSON.stringify(this.data.influencersList));
  }
  ngOnInit(): void {}
  goToLocation(rank: any) {
    console.log(' rank selected' + rank)
    let data = this.data.influencersList.find(x => x.rank === rank);
    if (data) {
      this.data.countryLocation = new CountryData();
      this.data.countryLocation.boundSWLong = data.countryMapData.boundSWLong;
      this.data.countryLocation.boundsNELat = data.countryMapData.boundsNELat;
      this.data.countryLocation.boundsNELong = data.countryMapData.boundsNELong;

      this.data.countryLocation.boundsSWLat = data.countryMapData.boundsSWLat;
      this.data.countryLocation.id = data.countryMapData.id;
      this.data.countryLocation.influencerID = data.countryMapData.influencerID;

      this.data.countryLocation.locationLat = data.countryMapData.locationLat;
      this.data.countryLocation.locationLong = data.countryMapData.locationLong;
      this.data.countryLocation.placeID = data.countryMapData.placeID;

       this.data.countryLocation.viewPortNELat = data.countryMapData.viewPortNELat;
       this.data.countryLocation.viewPortNELong = data.countryMapData.viewPortNELong;
      this.data.countryLocation.viewPortSWLat = data.countryMapData.viewPortSWLat;
      this.data.countryLocation.viewPortSWLong =data.countryMapData.viewPortSWLong;





    }

    this.router.navigate(['/location', {queryParams: {rank: rank}}]);

}
}
