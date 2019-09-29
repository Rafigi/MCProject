namespace McWorld.Address
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class CreateAddressCommand : ICommand
    {
        List<Address> _addressList = new List<Address>();
        public CreateAddressCommand(ICollection<Address> addresses)
        {
            foreach (var address in addresses)
            {
                _addressList.Add(new Address()
                {
                    AddressId = address.AddressId,
                    StreetName = address.StreetName,
                    StreetNumber = address.StreetNumber,
                    City = address.City,
                    Country = address.Country,
                    Zipcode = address.Zipcode,
                    Latitude = address.Latitude,
                    Longitude = address.Longitude
                });
            }
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            unitOfWork.Adresses.AddRange(_addressList);
            return Task.CompletedTask;
        }
    }
}
