"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Route = /** @class */ (function () {
    function Route() {
        this.RouteID = undefined;
        this.Distance = "0";
        this.Motorway = false;
        this.Ferry = false;
        this.Toll = false;
        this.Created = undefined;
        this.UserID = undefined;
        this.Addresses = new Array(2);
    }
    Route.prototype.CreateRoute = function (distance, ferry, toll, motorway, startAddress, endAddress) {
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
    };
    return Route;
}());
exports.default = Route;
//# sourceMappingURL=Route.js.map