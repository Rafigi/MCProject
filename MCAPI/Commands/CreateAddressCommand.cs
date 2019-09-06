using MCAPI.Models;
using MCAPI.Persistence;
using System;

namespace MCAPI.Commands
{
    public class CreateAddressCommand : ICommand
    {
        IUnitOfWork _unitOfWork;
        public Address Address { get; private set; }
        public CreateAddressCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateAddressCommand(Guid addressID, Address address)
        {
            Address = new Address()
            {

                AddressID = addressID,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                Country = address.Country,
                Zipcode = address.Zipcode,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }

        public void Complete()
        {
            _unitOfWork.Adresses.Add(Address);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
