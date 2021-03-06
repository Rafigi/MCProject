﻿namespace McWorld.Shared.Factory
{
    using McWorld.Shared.Models;
    using System;

    class AddressFactory : IAddressFactory
    {
        public Address Create(Address address)
        {
            return new Address()
            {
                AddressId = Guid.NewGuid(),
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                Country = address.Country,
                Zipcode = address.Zipcode,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }
    }
}
