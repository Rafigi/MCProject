import Address from '../Models/Address';
export default class Route {
  RouteID: number = undefined;
  Distance: number = 0;
  Motorway: boolean = false;
  Ferry: boolean = false;
  Toll: boolean = false;
  Created: string = undefined;
  UserID: number = undefined
  Addresses: Array<Address> = new Array<Address>(2);

  constructor() { }

  CreateRoute(distance: number, ferry: boolean, toll: boolean, motorway: boolean, startAddress: Address, endAddress: Address) {
    this.Distance = distance;
    this.Ferry = ferry;
    this.Toll = toll;
    this.Motorway = motorway;
    this.Created = undefined;
    this.RouteID = undefined;
    this.UserID = undefined;
    this.Addresses = [
      {
        AddressId: undefined,
        StreetName: startAddress.StreetName,
        StreetNumber: startAddress.StreetNumber,
        City: startAddress.City,
        Country: startAddress.Country,
        Zipcode: startAddress.Zipcode,
        Longitude: '00000000000',
        Latitude: '111111111111'
      },
      {
        AddressId: undefined,
        StreetName: endAddress.StreetName,
        StreetNumber: endAddress.StreetNumber,
        City: endAddress.City,
        Country: endAddress.Country,
        Zipcode: endAddress.Zipcode,
        Longitude: '2222222222222',
        Latitude: '33333333333333'
      }
    ];
  }
}
