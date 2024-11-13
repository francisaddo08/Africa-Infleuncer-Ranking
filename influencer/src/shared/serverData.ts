export interface IInfluencer {
  containerCssClass: string;
  imageCssClass: string;
  nameCssClass: string;
  rankCssClass: string;
  rank: number;
  positionInRow: number;
  rowGroup: number;
  name: string;
  isFaceBook: boolean;
  isYouTube: boolean;
  isInstagram: boolean;
  isTwitter: boolean;
  image: string;
  total: number;
  totalStringValue: string;
  countryMapData: CountryMapData;
  cMap: CityMapData;
}

export interface CountryMapData {
  id: number;
  influencerID: number;
  placeID: string;
  boundsNELat: number;
  boundsNELong: number;
  boundsSWLat: number;
  boundSWLong: number;
  viewPortNELat: number;
  viewPortNELong: number;
  viewPortSWLat: number;
  viewPortSWLong: number;
  locationLat: number;
  locationLong: number;
}

export interface CityMapData {
  id: number;
  influencerID: number;
  placeID: string;
  boundsNELat: number;
  boundsNELong: number;
  boundsSWLat: number;
  boundSWLong: number;
  viewPortNELat: number;
  viewPortNELong: number;
  viewPortSWLat: number;
  viewPortSWLong: number;
  locationLat: number;
  locationLong: number;
}
export class CountryMapData implements CountryMapData{
  id!: number;
  influencerID!: number;
  placeID!: string;
  boundsNELat!: number;
  boundsNELong!: number;
  boundsSWLat!: number;
  boundSWLong!: number;
  viewPortNELat!: number;
  viewPortNELong!: number;
  viewPortSWLat!: number;
  viewPortSWLong!: number;
  locationLat!: number;
  locationLong!: number;
}
