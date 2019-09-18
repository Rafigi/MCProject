
namespace MCAPI.McWorld.Shared.Factory
{
    using MCAPI.McWorld.Shared.Models;
    using System;
    public class AddressFactory : IAddressFactory
    {
        public Address Create(Address address)
        {
            return new Address()
            {
                AddressID = Guid.NewGuid(),
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                Country = address.Country,
                Zipcode = address.Zipcode,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }

        public Address Update(Address type)
        {
            throw new NotImplementedException();
        }
    }
}
