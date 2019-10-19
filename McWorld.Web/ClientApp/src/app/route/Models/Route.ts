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

  constructor() {}
}
