export class CelebeInfo {
  name: string = '';
  totalFollowers: number | undefined;
  description1: string = '';
  description2: string = '';
  description3: string = '';
  img: string = '';
  constructor(name: string, followers: number, des: string, img: string) {
    this.name = name;
    this.totalFollowers = followers;
    this.description1 = des;
    this.img = img;
  }
}

export interface ICelebeInfo {
  name: string ;
  totalFollowers: number;
  description1: string ;
  description2: string ;
  description3: string ;
  img: string;
  url: string;
}
export interface Influencer {
  id: number;
  name: string;
  totalFollowers: number;
  description1: string;
  description2: string;
  description3: string;
  imgUrl: string;
  social: Social[];
  geoLocation: GeoLocation;
}

export interface Social {

  name: string;
  url: string;
}
export interface GeoLocation {
  country: string;
  countryCode: string;
  state: string;
  region: string;
  city: string;
  postCode: string;
}
export interface GeoLocationViewModel {
  id: number;
  country: string;
  countryCode: string;
  state: string;
  region: string;
  city: string;
  postCode: string;
}

export interface Status {
  status: Status;
  data: Data;
}

export interface Data {
  id: ID;
  general: General;
  statistics: Statistics;
  misc: Misc;
  ranks: Ranks;
  badges: string[];
  daily: Daily[];
}

export interface Daily {
  date: Date;
  subs: number;
  views: number;
}

export interface General {
  created_at: Date;
  channel_type: string;
  geo: Geo;
  branding: Branding;
}

export interface Branding {
  avatar: string;
  banner: string;
  website: string;
  social: Social;
}

export interface Social {
  facebook: string;
  twitter: string;
  twitch: null;
  instagram: string;
  linkedin: null;
  discord: null;
  tiktok: null;
}

export interface Geo {
  country_code: string;
  country: string;
}

export interface ID {
  id: string;
  username: string;
  cusername: string;
  handle: string;
  display_name: string;
}

export interface Misc {
  grade: Grade;
  sb_verified: boolean;
  made_for_kids: boolean;
  tags: string[];
}

export interface Grade {
  color: string;
  grade: string;
}

export interface Ranks {
  sbrank: number;
  subscribers: number;
  views: number;
  country: number;
  channel_type: number;
}

export interface Statistics {
  total: Total;
  growth: Growth;
}

export interface Growth {
  subs: { [key: string]: number };
  vidviews: { [key: string]: number };
}

export interface Total {
  uploads: number;
  subscribers: number;
  views: number;
}
