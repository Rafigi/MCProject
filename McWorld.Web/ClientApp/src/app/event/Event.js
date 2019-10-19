"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Event = /** @class */ (function () {
    /*Constructor for Event */
    function Event() {
        //Properties
        this.EventID = undefined;
        this.Headline = '';
        this.Description = '';
        this.StartDate = new Date().toLocaleDateString();
        this.StartTime = this.SetTimeOfTheDay(0);
        this.EndDate = new Date().toLocaleDateString();
        this.EndTime = this.SetTimeOfTheDay(1);
        this.RegistrationCount = 0;
        this.Created = new Date().toLocaleDateString();
        this.UserID = undefined;
    }
    //Metodes 
    Event.prototype.UpdateEvent = function (headline, description, startTime, startDate, endDate, endTime) {
        this.Headline = headline;
        this.Description = description;
        this.StartDate = startDate;
        this.StartTime = startTime;
        this.EndDate = endDate;
        this.EndTime = endTime;
    };
    Event.prototype.UpdateRoute = function (distance, ferry, toll, motorway, startAddress, endAddress) {
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
    };
    Event.prototype.SetTimeOfTheDay = function (plusHour) {
        var hour = new Date().getHours();
        var minut = new Date().getMinutes();
        return hour + plusHour + ":" + minut;
    };
    return Event;
}());
exports.default = Event;
//# sourceMappingURL=Event.js.map