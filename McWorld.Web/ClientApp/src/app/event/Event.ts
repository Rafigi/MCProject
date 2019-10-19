import Route from '../route/Models/Route';
import Address from '../route/Models/Address';
export default class Event {
  //Properties
  EventID: number = undefined;
  Headline: string = '';
  Description: string = '';
  StartDate: string = new Date().toLocaleDateString();
  StartTime: string = this.SetTimeOfTheDay(0);
  EndDate: string = new Date().toLocaleDateString();
  EndTime: string = this.SetTimeOfTheDay(1);
  RegistrationCount: number = 0;
  Created: string = new Date().toLocaleDateString();
  UserID: number = undefined
  Route: Route;

  /*Constructor for Event */
  constructor() { }


  //Metodes 
  UpdateEvent(headline: string, description: string, startTime: string, startDate: string, endDate: string, endTime: string) {
    this.Headline = headline;
    this.Description = description;
    this.StartDate = startDate;
    this.StartTime = startTime;
    this.EndDate = endDate;
    this.EndTime = endTime;
  }

  UpdateRoute(distance: number, ferry: boolean, toll: boolean, motorway: boolean, startAddress: Address, endAddress: Address) {
    this.Route.Distance = distance;
    this.Route.Ferry = ferry;
    this.Route.Toll = toll;
    this.Route.Motorway = motorway;
    this.Route.Created = undefined;
    this.Route.RouteID = undefined;
    this.Route.UserID = undefined;
    this.Route.Addresses = [
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

  private SetTimeOfTheDay(plusHour: number): string {
    var hour = new Date().getHours();
    var minut = new Date().getMinutes();
    return hour + plusHour + ":" + minut;
  }
}
