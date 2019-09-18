namespace MCAPI.McWorld.Address
{
    using MCAPI.McWorld.Shared.Models;
    using MCAPI.McWorld.Shared.Messages;
    using MCAPI.McWorld.Shared.Persistence;
    using System.Threading.Tasks;
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
