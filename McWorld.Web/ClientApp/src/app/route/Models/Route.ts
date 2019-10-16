import Address from './Address';
export default interface Route {
  RouteID: number;
  Distance: number;
  Motorway: boolean;
  Ferry: boolean;
  Toll: boolean;
  Created: string;
  UserID: number;
  Addresses: Address;
}
