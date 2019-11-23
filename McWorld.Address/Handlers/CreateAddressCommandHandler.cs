namespace McWorld.Address.Handlers
{
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using McWorld.Shared.Models;
    class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand>
    {
        private readonly IAdresseRepository _adresseRepository;
        private readonly IAddressFactory _addressFactory;
        List<Address> addresses = new List<Address>();

        public CreateAddressCommandHandler(IAdresseRepository adresseRepository, IAddressFactory addressFactory)
        {
            _adresseRepository = adresseRepository;
            _addressFactory = addressFactory;
        }
        public Task ExecuteAsync(CreateAddressCommand message)
        {
            foreach (var item in message.Addresses)
            {
                addresses.Add(_addressFactory.Create(item));
            }
            _adresseRepository.AddRange(addresses);

            return Task.CompletedTask;
        }
    }
}
