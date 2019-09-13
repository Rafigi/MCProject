using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCAPI.Models;

namespace MCAPI.Factory
{
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
