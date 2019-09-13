using MCAPI.Models;
using MCAPI.Persistence;
using System;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
    public class CreateAddressCommand : ICommand
    {
        public Address Address { get; private set; }

        public CreateAddressCommand(Address address)
        {
            Address = new Address()
            {
                AddressID = address.AddressID,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                Country = address.Country,
                Zipcode = address.Zipcode,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            unitOfWork.Adresses.Add(Address);
            return Task.CompletedTask;
        }
    }
}
