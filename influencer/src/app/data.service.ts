import { CountryData } from './../shared/IInfluencer';
import { IInfluencer, CountryMapData } from './../shared/serverData';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';
import {
  Influencer,
  ICelebeInfo,
  GeoLocationViewModel,
} from 'src/shared/celebInfo';
import { GeocoderResponse } from 'src/shared/geoLocation';
import { IfStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  dataUrl: string = 'http://localhost:13676/api/home';
  private InfluencerUrl: string = 'http://localhost:13676/api/Influencer/';
  public googleApiKey: string = 'AIzaSyCPGYo60CvaT5QNItLyDgklWmK34Zxacgc';
  public serverData: Influencer[] = [];

  public influencersList: IInfluencer[] = [];
  public topRankedOnly: IInfluencer[] = [];
  public top4: IInfluencer[] = [];
  public from6To27: IInfluencer[] = [];
  public bottom3: IInfluencer[] = [];
  public rowOne: IInfluencer[] = [];
  public rowTwo: IInfluencer[] = [];
  public rowThree: IInfluencer[] = [];
  public rowFour: IInfluencer[] = [];
  public countryLocation: CountryData = new CountryData();

  public celebData: ICelebeInfo[] = [
    {
      name: 'd',
      totalFollowers: 19,
      description1: 'd',
      description2: 's',
      description3: 'f',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 25,
      description1: 's',
      description2: 'sd',
      description3: 'sd',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 9,
      description1: 'w',
      description2: 'w',
      description3: 'e',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 23,
      description1: 'e',
      description2: 'w',
      description3: 'w',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 5,
      description1: 'd',
      description2: 'd',
      description3: 'd',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 19,
      description1: 'd',
      description2: 's',
      description3: 'f',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 25,
      description1: 's',
      description2: 'sd',
      description3: 'sd',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 9,
      description1: 'w',
      description2: 'w',
      description3: 'e',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 23,
      description1: 'e',
      description2: 'w',
      description3: 'w',
      img: '../../assets/logo4.webp',
      url: '',
    },
    {
      name: 'd',
      totalFollowers: 5,
      description1: 'd',
      description2: 'd',
      description3: 'd',
      img: '../../assets/logo4.webp',
      url: '',
    },
  ];
  public initialLocationLat: any;
  public initialLocationLong: any;
  public celebLocation: string = '';
  public celebLocationLong: number = 0;
  public celebLocationLat: number = 0;
  public response!: GeocoderResponse;
  public SelectedCeleb: number = 0;

  public location!: Location;
  constructor(private http: HttpClient) {
    // this.codeAddress('accra');
    /*  this.getLocation('accra').subscribe({
      next: (data) => {
        this.response = data;
      },
      error: (err) => {},
    }); */

    /*   this.getLocation('accra').subscribe({
      next: (data) => { console.log('this.getLocation accra ' + data) }, error: (err) => {},

    }); */
    //==========================================================================
    /*  this.getGeoLocationData('odumase-krobo + eastern region ').subscribe({
      next: (data) => {
        this.response = data;

      },
      error: (err) => {},
    }); */
    //==========================================================

    //================================================================
    this.getInfluensers().subscribe({
      next: (data: IInfluencer[]) => {
        this.influencersList = data;
        this.setRowOne(this.influencersList);
        this.setRowTwo(data);
        this.setRowThree(data);
        this.setRowFour(data);

        /*  console.log('Influencer list   ' + this.influencersList);
        console.log("row one" + this.rowOne ) */
      },
      error: (err) => {},
    });
    //======================================================================
  }

  private setRowOne(list: IInfluencer[]): void {
    list.forEach((x) => {
      if (x.rowGroup === 1) {
        if (x.rank === 1) {
          this.topRankedOnly.push(x);
        }
        if (x.rank > 1 && x.rank < 14) {
          this.top4.push(x);
        }

        this.rowOne.push(x);
      }
    });
    this.rowOne.sort((a, b) => a.positionInRow - b.positionInRow);
    console.log('row one methos' + JSON.stringify(this.rowOne));
  }
  private setRowTwo(list: IInfluencer[]): void {
    list.forEach((x) => {
      if (x.rowGroup === 2) {
        this.rowTwo.push(x);
      }
      if (x.rank > 6 && x.rank < 27) {
        this.from6To27.push(x);
      }
      if (x.rank > 27 && x.rank < 31) {
        this.bottom3.push(x);
      }
    });
    this.rowTwo.sort((a, b) => a.positionInRow - b.positionInRow);

    console.log('row 2 methos' + JSON.stringify(this.rowTwo));
  }
  private setRowThree(list: IInfluencer[]): void {
    list.forEach((x) => {
      if (x.rowGroup === 3) {
        this.rowThree.push(x);
      }
    });
    this.rowThree.sort((a, b) => a.positionInRow - b.positionInRow);

    console.log('row one methos' + JSON.stringify(this.rowThree));
  }
  private setRowFour(list: IInfluencer[]): void {
    list.forEach((x) => {
      if (x.rowGroup === 4) {
        this.rowFour.push(x);
      }
    });
  }
  //==========================================================

  getInfluensers(): Observable<IInfluencer[]> {
    return this.http.get<IInfluencer[]>(this.InfluencerUrl).pipe(
      tap((data: IInfluencer[]) => {
        this.influencersList = data;
        /*  console.log(
          'Influencer list get method ' + JSON.stringify(this.influencersList)
        ); */
      })
    );
  }

  /*  getLocation(term: string): Observable<GeocoderResponse> {
    const urlmap =
      'https://maps.googleapis.com/maps/api/geocode/json?address=${term}&key=AIzaSyCPGYo60CvaT5QNItLyDgklWmK34Zxacgc';
    const url = `https://maps.google.com/maps/api/geocode/json?address=${term}&sensor=false&key=$googleApiKey`;
    return this.http.get<GeocoderResponse>(urlmap).pipe(
      tap((data: any) => {
        console.log('map data with string  ' + JSON.stringify(data));
      })
    );
  } */
  /*  getCelebData(): Observable<Influencer[]> {
    // http.get returns an  of Observable obj like a list of obj
    return this.http.get<Influencer[]>(this.dataUrl).pipe(
      //we pass the return data without manupulatio);
      tap((data: Influencer[]) =>
        console.log('Avaliable Influencers ' + JSON.stringify(data))
      ),
      catchError(this.handleError)
    );
  } */
  /* setGeoLocations(location: GeoLocationViewModel) {}

  public getGeoLocationData(term: string): Observable<GeocoderResponse> {
    // http.get returns an  of Observable obj like a list of obj

    const url =
      'https://maps.googleapis.com/maps/api/geocode/json?address=' +
      term +
      '&key=AIzaSyCPGYo60CvaT5QNItLyDgklWmK34Zxacgc';

    return this.http.get<GeocoderResponse>(url).pipe(
      //we pass the return data without manupulatio);
      tap((data: GeocoderResponse) =>
        console.log('Geolocation from string ' + JSON.stringify(data))
      ),
      catchError(this.handleError)
    );
  }
  //=============================================async=================================
 */
  /* async getPrice(term: string): Promise<any> {
    const url =
      'https://maps.googleapis.com/maps/api/geocode/json?address=' +
      term +
      '&key=AIzaSyCPGYo60CvaT5QNItLyDgklWmK34Zxacgc';

    return this.http.get<any>(url).toPromise();
  }
  //=========================================               =============================
  public getGeoLocationDataAsync(term: string) {
    // http.get returns an  of Observable obj like a list of obj

    const url =
      'https://maps.googleapis.com/maps/api/geocode/json?address=' +
      term +
      '&key=AIzaSyCPGYo60CvaT5QNItLyDgklWmK34Zxacgc';

    return this.http.get<GeocoderResponse>(url);
  } */
  //====================================================================================

  // to handle errors from the http requset we create a method on the service useing HttpErrorRespose obj as a para
  private handleError(err: HttpErrorResponse) {
    let errorMessage = ``;
    if (err.error instanceof ErrorEvent) {
      //client side error, network connection or mishaps
      errorMessage = `An erreor happened: ${err.error.message} `;
    } else {
      // Server side error,  server return db code or anything
      errorMessage = `Server return code: ${err.status}, error message is : ${err.message}`;
    }
    console.log(errorMessage); // log to console
    return throwError(errorMessage);
  }
}
